using IdentityServer4.Extensions;
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
    public class EmailController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        public EmailController(IConfiguration configuration,
                               SignInManager<ApplicationUser> signInManager,
                                ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("api/GetFirmMailSettings")]
        public async Task<IActionResult> GetFirmMailSettings()
        {
            var companyID = new Guid(User.Claims.FirstOrDefault(x => x.Type == "CompanyID").Value);
            var emailSetting = _dbContext.FirmEmailSettings.Where(em => em.Firm.ID == companyID).FirstOrDefault();
            
            return Ok(emailSetting);
        }

        [HttpPost]
        [Route("api/UpdateMailSettings")]
        public async Task<IActionResult> UpdateMailSettings([FromBody] EmailSettingModel emailSettingModel)
        {
            var companyID = new Guid(User.Claims.FirstOrDefault(x => x.Type == "CompanyID").Value);
            var emailSetting = _dbContext.FirmEmailSettings.Where(em => em.Firm.ID == companyID).FirstOrDefault();

            if (emailSetting != null)
            {
                emailSetting.FromAddress = emailSettingModel.FromAddress;
                emailSetting.HostAddress = emailSettingModel.HostAddress;
                emailSetting.UseSsl = emailSettingModel.UseSsl;
                emailSetting.Username = emailSettingModel.Username;
                emailSetting.Password = emailSettingModel.Password;
                emailSetting.Port = emailSettingModel.Port;
                _dbContext.FirmEmailSettings.Update(emailSetting);
                _dbContext.SaveChanges();
            }
            else
            {
                FirmEmailSetting firmEmailSettings = new FirmEmailSetting();
                firmEmailSettings.FromAddress = emailSettingModel.FromAddress;
                firmEmailSettings.HostAddress = emailSettingModel.HostAddress;
                firmEmailSettings.UseSsl = emailSettingModel.UseSsl;
                firmEmailSettings.Username = emailSettingModel.Username;
                firmEmailSettings.Password = emailSettingModel.Password;
                firmEmailSettings.Port = emailSettingModel.Port;
                _dbContext.FirmEmailSettings.Add(firmEmailSettings);
                _dbContext.SaveChanges();
                var firm = _dbContext.Firms.Where(f => f.ID == companyID).FirstOrDefault();
                if (firm != null)
                {
                    firm.FirmEmailSettingID = firmEmailSettings.ID;
                    _dbContext.SaveChanges();
                }
            }

            return Ok(new ScreenSubmitResult { Successful = true });
        }

    }
}
