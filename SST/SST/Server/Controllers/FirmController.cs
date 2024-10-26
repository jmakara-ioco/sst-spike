using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SST.Server.Data;
using SST.Shared;

namespace SST.Server
{
    [ApiController]
    public class FirmController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        public FirmController(IConfiguration configuration,
                               SignInManager<ApplicationUser> signInManager,
                               ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("api/GetFirmProfile")]
        public async Task<IActionResult> GetFirmProfile()
        {
            var companyID = new Guid(User.Claims.FirstOrDefault(x => x.Type == "CompanyID").Value);
            var company = _dbContext.Firms.Include("Address").Where(f => f.ID == companyID).FirstOrDefault();
            if (company.Address == null)
            {
                company.Address = new Address();
            }
            return Ok(company);
        }

        [HttpGet]
        [Route("api/GetStoreInfo/{firmID}")]
        public async Task<IActionResult> GetStoreModel(Guid firmID)
        {
            var retVal = _dbContext.PaymentGates.FirstOrDefault(x => x.FirmID == firmID);
            if(retVal != null)
            return Ok(new StoreModel() { Caption = retVal.OnlineStoreName, IsEnabled = retVal.EnableOnlineStore });
            else
            return Ok(new StoreModel());
        }
        [HttpPost]
        [Route("api/UpdateFirmSettings")]
        public async Task<IActionResult> UpdateFirmSettings([FromBody] FirmModel firmModel)
        {
            try
            {
                var companyID = new Guid(User.Claims.FirstOrDefault(x => x.Type == "CompanyID").Value);
                var firm = _dbContext.Firms.Include(x => x.Address ).Where(f => f.ID == companyID).FirstOrDefault();

                if (firm != null)
                {
                    firm.FirmName = firmModel.FirmName;
                    firm.ContactNumber = firmModel.ContactNumber;
                    firm.RegistrationNumber = firmModel.RegistrationNumber;
                    firm.VatNumber = firmModel.VatNumber;
                    if(firm.Address == null)
                    {
                       var address = new Address() {
                             City = firmModel.Address.City,
                             PostalCode = firmModel.Address.PostalCode,
                             Street1 = firmModel.Address.Street1,
                             Street2 = firmModel.Address.Street2,
                             Suburb = firmModel.Address.Suburb,
                             Country = firmModel.Address.Country
                        };
                        _dbContext.Set<Address>().Add(address);
                        firm.AddressID = address.ID;

                    }
                    else
                    {
                        firm.Address.City = firmModel.Address.City;
                        firm.Address.PostalCode = firmModel.Address.PostalCode;
                        firm.Address.Street1 = firmModel.Address.Street1;
                        firm.Address.Street2 = firmModel.Address.Street2;
                        firm.Address.Suburb = firmModel.Address.Suburb;
                        firm.Address.Country = firmModel.Address.Country;
                    }


                    _dbContext.SaveChanges();
                }


                return Ok(new ScreenSubmitResult { Successful = true });
            }
            catch (Exception ex)
            {
                return Ok(new ScreenSubmitResult { Successful = false, Errors = new List<String>() { ex.Message } });
            }
        }
    }
}
