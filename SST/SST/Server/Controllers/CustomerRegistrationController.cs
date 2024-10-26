using Microsoft.AspNetCore.Mvc;
using SST.Client;
using SST.Server.Data;
using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SST.Server.Controllers
{
    [ApiController]

    public class CustomerRegistrationController : ControllerBase
    {
        private ApplicationDbContext _context { get; set; }
        public CustomerRegistrationController(ApplicationDbContext context)
        {
            this._context = context;
        }
        //[Route("api/createinviteemail")]
        //[HttpPost]
        //public async Task<ScreenSubmitResult> CreateInviteEmail(CustomerRegisterModel customerRegisterModel)
        //{

        //    var mailSetting = _context.Set<FirmEmailSettings>().FirstOrDefault(x => x. == (int)EmailUsedFor.AccountActivation);
        //    var url = $"{Request.Scheme}://{Request.Host.Value}";

        //    _context.SaveChanges();
            
        //    string token = customer.ID.ToString();
        //    string emailBody = SortedConstants.ClientOnboardingBody.Replace("{url}", url, StringComparison.CurrentCultureIgnoreCase);
        //    emailBody = emailBody.Replace("{Tenant}", company.CompanyName, StringComparison.CurrentCultureIgnoreCase);
        //    emailBody = emailBody.Replace("{token}", token, StringComparison.CurrentCultureIgnoreCase);

        //    await Mailer.SendEmailSmtp(SortedConstants.ClientOnboardingSubject, emailBody, customerRegisterModel.Email, mailSetting, "Header", "Footer");

        //    return new ScreenSubmitResult() { Errors = new List<string>(), Successful = true };
        //}

    }

}
