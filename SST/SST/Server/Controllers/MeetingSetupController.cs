using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SST.Server.Data;
using SST.Shared;

namespace SST.Server.Controllers
{
    [ApiController]
    public class MeetingSetupController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public MeetingSetupController(IConfiguration configuration,
                               ApplicationDbContext context,
                               UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _dbContext = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        [Route("api/GetFirmMeetingSetup")]
        public async Task<IActionResult> GetFirmMeetingSetup()
        {
            var companyID = new Guid(User.Claims.FirstOrDefault(x => x.Type == "CompanyID").Value);
            var FirmMeetingSetup = _dbContext.FirmMeetingSetups.FirstOrDefault(f => f.FirmID == companyID);
            if (FirmMeetingSetup == null)
            {
                FirmMeetingSetup = new FirmMeetingSetup();
            }
            return Ok(new AutomaticMeetingSetupModel { AllowMeetings = FirmMeetingSetup.AllowMeetings, AllowPhysical = FirmMeetingSetup.AllowPhysical, AllowElectronicMeetings = FirmMeetingSetup.AllowElectrical, AllowPublicHolidays = FirmMeetingSetup.AllowPublicHolidays });
        }

        [HttpPost]
        [Authorize]
        [Route("api/UpdateFirmMeetingSetup")]
        public async Task<IActionResult> UpdateFirmMeetingSetup([FromBody] AutomaticMeetingSetupModel automaticMeetingSetup)
        {
            var companyID = new Guid(User.Claims.FirstOrDefault(x => x.Type == "CompanyID").Value);
            var FirmMeetingSetup = _dbContext.FirmMeetingSetups.FirstOrDefault(f => f.FirmID == companyID);
            if (FirmMeetingSetup == null)
            {
                FirmMeetingSetup = new FirmMeetingSetup();
                FirmMeetingSetup.FirmID = companyID;
                FirmMeetingSetup.AllowMeetings = automaticMeetingSetup.AllowMeetings;
                FirmMeetingSetup.AllowPhysical = automaticMeetingSetup.AllowPhysical;
                FirmMeetingSetup.AllowElectrical = automaticMeetingSetup.AllowElectronicMeetings;
                FirmMeetingSetup.AllowPublicHolidays = automaticMeetingSetup.AllowPublicHolidays;
                _dbContext.FirmMeetingSetups.Add(FirmMeetingSetup);
            }
            else
            {
                FirmMeetingSetup.AllowMeetings = automaticMeetingSetup.AllowMeetings;
                FirmMeetingSetup.AllowPhysical = automaticMeetingSetup.AllowPhysical;
                FirmMeetingSetup.AllowElectrical = automaticMeetingSetup.AllowElectronicMeetings;
                FirmMeetingSetup.AllowPublicHolidays = automaticMeetingSetup.AllowPublicHolidays;
                _dbContext.FirmMeetingSetups.Update(FirmMeetingSetup);
            }
            await _dbContext.SaveChangesAsync();
            return Ok(new ScreenSubmitResult { Successful = true });
        }
    }
}
