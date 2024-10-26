using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SST.Server.Data;
using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using VezaVI.Light.ServerExtensions;
using VezaVI.Light.Shared;

namespace SST.Server
{
    
    [ApiController]
    public class PaymentGateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PaymentGateController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/DefaultPaymentGate")]
        public async Task<ActionResult<PaymentGate>> GetDefaultPaymentGate()
        {
            var company = User.Claims.FirstOrDefault(x => x.Type == "CompanyID");
            Guid? firmID = null;
            if (company != null)
                firmID = new Guid(company.Value);
            var paygate = _context.PaymentGates.FirstOrDefault(x => x.FirmID == firmID && x.Supplier == (int)PaymentSupplier.PayGate);
            if (paygate == null)
            {
                paygate = new PaymentGate()
                {
                    Supplier = (int)PaymentSupplier.PayGate,
                    FirmID = firmID
                };
            }
            return paygate;
        }

        [HttpPost]
        [Authorize]
        [Route("api/DefaultPaymentGate")]
        public async Task<VezaAPISubmitResult> PostDefaultPaymentGate([FromBody] PaymentGate paymentGate)
        {
            try
            {
                var paygate = _context.PaymentGates.FirstOrDefault(x => x.ID == paymentGate.ID);
                if (paygate == null)
                {
                    _context.PaymentGates.Add(paymentGate);
                }
                else
                {
                    paygate.APIKey = paymentGate.APIKey;
                    paygate.APIPassword = paymentGate.APIPassword;
                    paygate.EnableOnlineStore = paymentGate.EnableOnlineStore;
                    paygate.OnlineStoreName = paymentGate.OnlineStoreName;
                    paygate.UrlPrefects = paymentGate.UrlPrefects;
                }
                await _context.SaveChangesAsync();
                return VezaAPISubmitResult.Succeeded(paymentGate.ID);
            }
            catch (Exception ex)
            {
                return VezaAPISubmitResult.Failed(ex.Message);
            }
        }

        [Route("paymentresult")]
        [HttpPost]
        public IActionResult PaymentResult()
        {
            string CHECKSUM = Request.Form["CHECKSUM"];
            string PAYGATE_ID = Request.Form["PAYGATE_ID"];
            string REFERENCE = Request.Form["REFERENCE"];
            string TRANSACTION_STATUS = Request.Form["TRANSACTION_STATUS"];
            string RESULT_CODE = Request.Form["RESULT_CODE"];
            string AUTH_CODE = Request.Form["AUTH_CODE"];
            string AMOUNT = Request.Form["AMOUNT"];
            string RESULT_DESC = Request.Form["RESULT_DESC"];
            string TRANSACTION_ID = Request.Form["TRANSACTION_ID"];
            string SUBSCRIPTION_ID = Request.Form["SUBSCRIPTION_ID"];
            string RISK_INDICATOR = Request.Form["RISK_INDICATOR"];
            string KEY = "secret";

            var checkSum = VezaVIUtils.CreateMD5(PAYGATE_ID + "|" + REFERENCE + "|" + TRANSACTION_STATUS + "|" + RESULT_CODE + "|" + AUTH_CODE + "|" +
                    AMOUNT + "|" + RESULT_DESC + "|" + TRANSACTION_ID + "|" + SUBSCRIPTION_ID + "|" + RISK_INDICATOR + "|" + KEY);

            try
            {
                if (checkSum.ToLower() == CHECKSUM)
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        var invoice = _context.InvoiceHeaders.Include(x => x.Lines).FirstOrDefault(x => x.TransactionNumber == REFERENCE);
                        invoice.Status = 1;

                        var lastDate = DateTime.Now;
                        if (_context.FirmSubscriptionPlans.Count() > 0)
                            lastDate = _context.FirmSubscriptionPlans.Max(x => x.ExpiryDate);
                        var expiryDate = (lastDate <= DateTime.Now) ? DateTime.Now.AddDays(30) : lastDate.AddDays(30);
                        _context.FirmSubscriptionPlans.Add(new FirmSubscriptionPlan()
                        {
                             ExpiryDate = expiryDate,
                             FirmID = invoice.FirmID,
                             Description = invoice.Lines.FirstOrDefault().Description,
                             NrOFUsers = invoice.NrOfUsers,
                             InvoiceHeaderID = invoice.ID
                        });
                        _context.SaveChanges();
                        scope.Complete();
                    }
                    return Redirect("/confirmpaymentresult");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Payment Failed, please contact support for assistance. {ex.Message}");
            }
            return BadRequest("Payment Failed, please contact support for assistance.");
        }


        [HttpGet]
        [Route("api/GetTenantBySegment/{tenantSegment}")]
        public async Task<IActionResult> GetTenantBySegment(string tenantSegment)
        {
            var paygate = _context.PaymentGates.FirstOrDefault(x => x.UrlPrefects == tenantSegment);
            if (paygate == null)
                return Ok(Guid.Empty);
            return Ok(paygate.FirmID);
        }
    }
}
