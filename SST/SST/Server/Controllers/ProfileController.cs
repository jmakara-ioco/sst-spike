﻿using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
    public class ProfileController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(IConfiguration configuration,
                               SignInManager<ApplicationUser> signInManager,
                               UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        [Route("api/GetUserProfile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var userId = new Guid(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var user =  _signInManager.UserManager.Users.FirstOrDefault(x => x.Id == userId);

            return Ok(new ProfileModel { Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, ContactNumber = user.PhoneNumber });
        }

        [HttpPost]
        [Route("api/UpdateProfile")]
        public async Task<IActionResult> UpdateProfile([FromBody] ProfileModel profileModel)
        {
            var userId = new Guid(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var user = _signInManager.UserManager.Users.FirstOrDefault(x => x.Id == userId);

            user.Email = profileModel.Email;
            user.FirstName = profileModel.FirstName;
            user.LastName = profileModel.LastName;
            user.PhoneNumber = profileModel.ContactNumber;

            await _signInManager.UserManager.UpdateAsync(user);

            return Ok(new ScreenSubmitResult { Successful = true });
        }

        [HttpPost]
        [Authorize]
        [Route("api/ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel changePasswordModel)
        {
            var userId = new Guid(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var user = _signInManager.UserManager.Users.FirstOrDefault(x => x.Id == userId);
            await _userManager.ChangePasswordAsync(user, changePasswordModel.CurrentPassword, changePasswordModel.Password);
            return Ok(new ScreenSubmitResult { Successful = true });
        }

        [HttpPost]
        [Route("api/ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel forgotPasswordModel)
        {
            var user = _signInManager.UserManager.Users.FirstOrDefault(x => x.UserName == forgotPasswordModel.UserName);
            if (user != null)
            {
                Mailer mailer = new Mailer();
                string HostAddress = "kunlun.aserv.co.za";
                string HeaderImage = "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";
                string Body = "Please click on the following <a href='https://localhost:44323/newpassword/{UserID}'>link</a> to reset your password";
                Body = Body.Replace("{UserID}", user.Id.ToString());
                string FooterImage = "";
                string FromAddress = "test@n-abler.biz";
                int Port = 25;
                string Username = "test@n-abler.biz";
                string Password = "Password@1";
                await mailer.SendEmailSmtp(HostAddress, HeaderImage, Body, FooterImage, user.Email, FromAddress, "", "Password Reset Request", "Dear User",
                                        Port, Username, Password);
            }
            return Ok(new ScreenSubmitResult { Successful = true });
        }

        [HttpPost]
        [Route("api/NewPassword")]
        public async Task<IActionResult> NewPassword([FromBody] NewPasswordModel newPasswordModel)
        {
            var user = _signInManager.UserManager.Users.FirstOrDefault(x => x.Id == newPasswordModel.UserID);
            if (user != null)
            {
                await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user, newPasswordModel.Password);
            }
            return Ok(new ScreenSubmitResult { Successful = true });
        }
    }
}