using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SST.Server.Data;
using SST.Shared;

namespace SST.Server.Controllers
{
    [Route("api/Accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public AccountsController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterModel model)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var typeOfUser = (model.CompanyID == Guid.Empty) ? TypeOfUser.FirmAdministrator : TypeOfUser.ClientUser;
                    Guid? customerID = null;
                    Guid? firmID = null;
                    if (model.CompanyID != Guid.Empty)
                    {
                        /*Customer*/
                        Customer cust = new Customer();
                        cust.FirstName = model.FirstName;
                        cust.LastName = model.LastName;
                        cust.CompanyName = model.CompanyName;
                        _context.Add(cust);
                        customerID = cust.ID;
                        firmID = model.CompanyID;
                    }
                    else
                    {
                        /*Firm*/
                        Firm firm = new Firm();
                        firm.FirmName = model.CompanyName;
                        _context.Add(firm);
                        firmID = firm.ID;

                        var defaultSubscription = _context.SubscriptionPlans.FirstOrDefault(x => x.IsDefaultPlan);
                        if (defaultSubscription != null)
                        {
                            var max = 0;
                            if (_context.InvoiceHeaders.Count() > 0)
                                max = _context.InvoiceHeaders.Max(x => x.Sequence);
                            var nextSequence = max + 1;
                            InvoiceHeader invoiceHeader = new InvoiceHeader()
                            {
                                Currency = "ZAR",
                                FirmID = (Guid)firmID,
                                InvoiceDate = DateTime.Now,
                                InvoicedTo = model.CompanyName,
                                NrOfUsers = defaultSubscription.MaxUsers,
                                BillingFrequency = "MONTHLY",
                                Sequence = nextSequence,
                                Status = 0,
                                TransactionNumber = Guid.NewGuid().ToString()
                            };
                            invoiceHeader.Lines.Add(new InvoiceLine()
                            {
                                Description = $"Trail period for {defaultSubscription.MaxUsers} user{((defaultSubscription.MaxUsers > 1) ? "s" : "")}",
                                InvoiceID = invoiceHeader.ID,
                                Price = 0,
                                Quantity = 1,
                                DiscountPercentage = 0
                            });
                            _context.InvoiceHeaders.Add(invoiceHeader);
                            _context.FirmSubscriptionPlans.Add(new FirmSubscriptionPlan()
                            {
                                FirmID = firm.ID,
                                NrOFUsers = defaultSubscription.MaxUsers,
                                ExpiryDate = DateTime.UtcNow.AddDays(defaultSubscription.ValidForDays),
                                InvoiceHeaderID = invoiceHeader.ID
                            });
                        }
                    }

                    var newUser = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        TypeOfUser = (int)typeOfUser,
                        CustomerID = customerID,
                        FirmID = firmID
                    };
                    var result = await _userManager.CreateAsync(newUser, model.Password);

                    if (!result.Succeeded)
                    {
                        var errors = result.Errors.Select(x => x.Description);

                        return Ok(new ScreenSubmitResult { Successful = false, Errors = errors });
                    }
                    else
                    {
                        var role = (typeOfUser == TypeOfUser.FirmAdministrator) ? RoleConstants.FirmAdministrator : RoleConstants.ClientAdministrator;
                        await _userManager.AddToRoleAsync(newUser, role);
                    }
                    _context.SaveChanges();
                    scope.Complete();
                    return Ok(new ScreenSubmitResult { Successful = true });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
