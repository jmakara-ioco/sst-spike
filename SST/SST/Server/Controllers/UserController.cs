using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    [Route("api/Users")]
    [ApiController]
    public class UserController : VezaVIController<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async override Task<VezaAPISubmitResult> Post([FromBody] ApplicationUser item)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = await _userManager.CreateAsync(item, "Password@1");
                    if (!result.Succeeded)
                    {
                        var errors = result.Errors.Select(x => x.Description).FirstOrDefault();
                        return VezaAPISubmitResult.Failed(errors);
                    }
                    else
                    {
                        if (item.TypeOfUser == (int)TypeOfUser.SystemAdministrator)
                            await _userManager.AddToRoleAsync(item, RoleConstants.SystemAdministrator);
                        else if (item.TypeOfUser == (int)TypeOfUser.SystemEmployee)
                            await _userManager.AddToRoleAsync(item, RoleConstants.SystemEmployee);
                        else if (item.TypeOfUser == (int)TypeOfUser.FirmAdministrator)
                            await _userManager.AddToRoleAsync(item, RoleConstants.FirmAdministrator);
                        else if (item.TypeOfUser == (int)TypeOfUser.FirmEmployee)
                            await _userManager.AddToRoleAsync(item, RoleConstants.FirmEmployee);
                        else if (item.TypeOfUser == (int)TypeOfUser.ClientAdministrator)
                            await _userManager.AddToRoleAsync(item, RoleConstants.ClientAdministrator);
                        else if (item.TypeOfUser == (int)TypeOfUser.ClientUser)
                            await _userManager.AddToRoleAsync(item, RoleConstants.ClientUser);
                    }
                    scope.Complete();
                }
                return VezaAPISubmitResult.Succeeded(item.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
