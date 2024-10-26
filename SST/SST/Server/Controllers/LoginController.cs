using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SST.Server.Data;
using SST.Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace SST.Server.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public LoginController(IConfiguration configuration,
                               SignInManager<ApplicationUser> signInManager,
                               ApplicationDbContext context)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpPost]
        [Route("api/Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);
            if (!result.Succeeded) return BadRequest(new LoginResult { Successful = false, Errors = new string[] { "Username and password are invalid." } });
            var user = await _signInManager.UserManager.FindByEmailAsync(login.Email);
            var roles = await _signInManager.UserManager.GetRolesAsync(user);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, login.Email),
            };
            if (user.FirmID != null)
                claims.Add(new Claim("CompanyID", user.FirmID.ToString()));
            if (user.CustomerID != null)
            {
                claims.Add(new Claim("CustomerID", user.CustomerID?.ToString()));
                var customer = _context.Customers.FirstOrDefault(x => x.ID == user.CustomerID);
                if (customer.AllowLogin == false) return BadRequest(new LoginResult { Successful = false, Errors = new string[] { "This account is not flagged to allow login please contact the firm that invited you." } });
            }               

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            //if (user.PasswordExpiryDate > DateTime.Now)
            //{
            return Ok(new LoginResult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
            //}
            //else
            //{
            //    return Ok(new LoginResult { Successful = false, Token = new JwtSecurityTokenHandler().WriteToken(token), Errors = new string[] { "Password Expired" } });
            //}
        }

    }
}
