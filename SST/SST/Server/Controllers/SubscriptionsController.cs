using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SST.Server.Data;
using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;
using VezaVI.Light.Shared;

namespace SST.Server
{
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;


        public SubscriptionsController(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        [Route("api/GetAvailablePlans/{users}")]
        public async Task<IActionResult> GetAvailablePlans(int users)
        {
            try
            {
                var subPlan = _dbContext.SubscriptionPlans.Where(x => x.IsActive).OrderBy(x => x.MaxUsers).FirstOrDefault(x => x.MaxUsers >= users);
                return Ok(subPlan);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorize]
        [Route("api/ActivatePlan")]
        public async Task<IActionResult> ActivatePlan(Guid id)
        {
            try
            {
                var companyID = new Guid(User.Claims.FirstOrDefault(x => x.Type == "CompanyID").Value);
                //Generate Invoice, return invoice ID for Payment

                /*_dbContext.CompanyIntroSteps.Add(new Shared.CompanyIntroStep()
                {
                    CompanyID = companyID,
                    IntroStepID = id
                });
                _dbContext.SaveChanges();*/
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/ActivePlan")]
        public async Task<IActionResult> ActivePlan()
        {
            try
            {
                //CustomerID
                var customer = User.Claims.FirstOrDefault(x => x.Type == "CustomerID");
                if (customer != null)
                {
                    var subscriptionPlan = new Shared.FirmSubscriptionPlan()
                    {
                        ExpiryDate = DateTime.UtcNow.Add(new TimeSpan(100, 0, 0, 0)),
                        Description = "Customer User",
                        NrOFUsers = 2
                    };
                    return Ok(subscriptionPlan);
                }
                else
                {
                    var company = User.Claims.FirstOrDefault(x => x.Type == "CompanyID");
                    if (company != null)
                    {
                        var companyID = new Guid(company.Value);
                        var subscriptionPlan = _dbContext.FirmSubscriptionPlans.OrderByDescending(x => x.ExpiryDate).FirstOrDefault(x => x.FirmID == companyID);
                        if (subscriptionPlan == null)
                            subscriptionPlan = new Shared.FirmSubscriptionPlan() { ExpiryDate = DateTime.UtcNow.Subtract(new TimeSpan(24, 0, 0)), Description = "No Plan Activated", NrOFUsers = 1 };
                        else
                            subscriptionPlan.Description = subscriptionPlan.Description;
                        return Ok(subscriptionPlan);
                    }
                    else
                    {
                        var subscriptionPlan = new Shared.FirmSubscriptionPlan()
                        {
                            ExpiryDate = DateTime.UtcNow.Add(new TimeSpan(100, 0, 0, 0)),
                            Description = "System User",
                            NrOFUsers = 200
                        };
                        return Ok(subscriptionPlan);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorize]
        [Route("api/GenerateSubscriptionInvoice")]
        public async Task<VezaAPISubmitResult> GenerateSubscriptionInvoice([FromBody] SubscriptionToken token)
        {
            try
            {
                var company = User.Claims.FirstOrDefault(x => x.Type == "CompanyID");
                if (company != null) {
                    var companyID = new Guid(company.Value);
                    var companyInfo = _dbContext.Firms.FirstOrDefault(x => x.ID == companyID);

                    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        /*Open Invoice?*/
                        var invoiceHeader = _dbContext.InvoiceHeaders.Include(x => x.Lines).FirstOrDefault(x => x.FirmID == companyID && x.Status == 0);
                        if (invoiceHeader == null)
                        {
                            var max = 0;
                            if (_dbContext.InvoiceHeaders.Count() > 0)
                                max = _dbContext.InvoiceHeaders.Max(x => x.Sequence);
                            var nextSequence = max + 1;
                            invoiceHeader = new InvoiceHeader()
                            {
                                Currency = "ZAR",
                                FirmID = companyID,
                                InvoiceDate = DateTime.Now,
                                InvoicedTo = companyInfo.FirmName,
                                NrOfUsers = token.Users,
                                BillingFrequency = token.Frequency,
                                Sequence = nextSequence,
                                Status = 0,
                                TransactionNumber = Guid.NewGuid().ToString()
                            };
                            invoiceHeader.Lines.Add(new InvoiceLine()
                            {
                                Description = $"{token.Users} user{((token.Users > 1) ? "s" : "")} billed {token.Frequency}",
                                InvoiceID = invoiceHeader.ID,
                                Price = token.Amount,
                                Quantity = 1,
                                DiscountPercentage = 0
                            });
                            _dbContext.InvoiceHeaders.Add(invoiceHeader);
                            _dbContext.SaveChanges();
                        }
                        else
                        {
                            invoiceHeader.Currency = "ZAR";
                            invoiceHeader.InvoiceDate = DateTime.Now;
                            invoiceHeader.InvoicedTo = companyInfo.FirmName;
                            invoiceHeader.NrOfUsers = token.Users;
                            invoiceHeader.BillingFrequency = token.Frequency;
                            invoiceHeader.Status = 0;

                            var line = invoiceHeader.Lines.FirstOrDefault();
                            line.Description = $"{token.Users} user{((token.Users > 1) ? "s" : "")} billed {token.Frequency}";
                            line.Price = token.Amount;
                            line.Quantity = 1;
                            line.DiscountPercentage = 0;
                            _dbContext.SaveChanges();
                        }
                        scope.Complete();
                        return VezaAPISubmitResult.Succeeded(invoiceHeader.GetID());
                    }
                }
                return VezaAPISubmitResult.Failed("Failed to Generate Invoice, please try again.");
            }
            catch (Exception ex)
            {
                return VezaAPISubmitResult.Failed($"Failed to Generate Invoice, please try again. {ex.Message}");
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/GetInvoice/{id}")]
        public async Task<InvoiceHeader> GetInvoice(Guid id)
        {
            try
            {
                var company = User.Claims.FirstOrDefault(x => x.Type == "CompanyID");
                if (company != null)
                {
                    var companyID = new Guid(company.Value);
                    var invoice = _dbContext.InvoiceHeaders.Include(x => x.Lines).FirstOrDefault(x => x.ID == id && x.FirmID == companyID);
                    if (invoice != null)
                    {
                        return invoice;
                    }
                }
                return new InvoiceHeader() { ID = Guid.Empty };
            }
            catch (Exception ex)
            {
                return new InvoiceHeader() { ID = Guid.Empty };
            }
        }
    }
}
