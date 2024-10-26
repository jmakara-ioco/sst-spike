using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SST.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace SST.Server
{
    [ApiController]
    public class ToasterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        public ToasterController(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        [Route("api/GetNextToaster")]
        public async Task<IActionResult> GetNextToaster()
        {
            try
            {
                if (User.HasClaim(x => x.Type == "CompanyID"))
                {
                    var companyID = new Guid(User.Claims.FirstOrDefault(x => x.Type == "CompanyID").Value);
                    var nextSteps = _dbContext.IntroSteps.Where(c =>
                        !_dbContext.CompanyIntroSteps.Where(x => x.FirmID == companyID).Select(b => b.IntroStepID)
                        .Contains(c.ID)).OrderBy(x => x.Sequence);
                    var nextStep = nextSteps.FirstOrDefault();
                    return Ok(nextStep);
                }
                return Ok(null);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorize]
        [Route("api/CompleteToaster/{id}")]
        public async Task<IActionResult> CompleteAndNextToaster(Guid id)
        {
            try
            {
                var companyID = new Guid(User.Claims.FirstOrDefault(x => x.Type == "CompanyID").Value);
                _dbContext.CompanyIntroSteps.Add(new Shared.FirmIntroStep()
                {
                    FirmID = companyID,
                    IntroStepID = id
                });
                _dbContext.SaveChanges();
                return await GetNextToaster();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


    }
}
