using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SST.Server.Data;
using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VezaVI.Light.ServerExtensions;
using VezaVI.Light.Shared;

namespace SST.Server
{
    [ApiController]

    
    public class StoreController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly SignInManager<StoreCustomer> _signInManager;
        private readonly UserManager<StoreCustomer> _userManager;

        public StoreController(IConfiguration configuration,
                               SignInManager<StoreCustomer> signInManager,
                               UserManager<StoreCustomer> userManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        [Route("api/GetStoreUser")]
        public async Task<IActionResult> GetStoreUser()
        {
            var storeuserId = new Guid(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var storeuser = _signInManager.UserManager.Users.FirstOrDefault(x => x.ID == storeuserId);

            return Ok(new StoreCustomer { Email = storeuser.Email, FirstName = storeuser.FirstName, LastName = storeuser.LastName });
        }

        [HttpPost]
        [Route("api/UpdateStoreUser")]
        public async Task<IActionResult> UpdateStoreUser([FromBody] StoreCustomer storeModel)
        {
            var storeuserId = new Guid(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var storeuser = _signInManager.UserManager.Users.FirstOrDefault(x => x.ID == storeuserId);

            storeuser.Email = storeModel.Email;
            storeuser.FirstName = storeModel.FirstName;
            storeuser.LastName = storeModel.LastName;
            await _signInManager.UserManager.UpdateAsync(storeuser);

            return Ok(new ScreenSubmitResult { Successful = true });
        }

    }
}
