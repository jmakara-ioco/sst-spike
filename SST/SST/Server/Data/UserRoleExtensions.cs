using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SST.Server
{
    public class UserRoleExtensions
    {
        internal static async Task CreateDefaultRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { 
                RoleConstants.SystemAdministrator,
                RoleConstants.SystemEmployee,
                RoleConstants.FirmAdministrator,
                RoleConstants.FirmEmployee,
                RoleConstants.ClientAdministrator,
                RoleConstants.ClientUser
            };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new ApplicationRole(roleName));
                }
            }
            List<ApplicationUser> users = new List<ApplicationUser>() {
                new ApplicationUser
                {
                    UserName = configuration["AppSettings:AdminUserEmail"],
                    Email = configuration["AppSettings:AdminUserEmail"],
                    TypeOfUser = (int)TypeOfUser.SystemAdministrator,
                    PasswordExpiryDate = DateTime.Now.AddDays(30)
                },
                new ApplicationUser
                {
                    Id = new Guid("{E4D2A033-3805-4A26-A33B-E0E82582899F}"),
                    UserName = "pieter@sst.co.za",
                    Email = "pieter@sst.co.za",
                    TypeOfUser = (int)TypeOfUser.SystemEmployee,
                    PasswordExpiryDate = DateTime.Now.AddDays(30)
                },
                new ApplicationUser
                {
                    Id = new Guid("{2AF22B4B-1845-4A76-88DF-4F4B40A70995}"),
                    UserName = "louis@sst.co.za",
                    Email = "louis@sst.co.za",
                    TypeOfUser = (int)TypeOfUser.SystemEmployee,
                    PasswordExpiryDate = DateTime.Now.AddDays(30)
                },
                new ApplicationUser
                {
                    Id = new Guid("{9FB91616-3ED5-4A9C-BBFC-9F25C45FE095}"),
                    UserName = "client@sst.co.za",
                    Email = "client@sst.co.za",
                    TypeOfUser = (int)TypeOfUser.ClientAdministrator,
                    PasswordExpiryDate = DateTime.Now.AddDays(30)
                }
            };

            string userPWD = configuration["AppSettings:AdminUserPassword"];

            foreach (var user in users)
            {
                var _user = await UserManager.FindByEmailAsync(user.Email);
                if (_user == null)
                {
                    var createPowerUser = await UserManager.CreateAsync(user, userPWD);
                    if (createPowerUser.Succeeded)
                    {
                        if ((TypeOfUser)user.TypeOfUser == TypeOfUser.SystemAdministrator)
                            await UserManager.AddToRoleAsync(user, RoleConstants.SystemAdministrator);
                        else if ((TypeOfUser)user.TypeOfUser == TypeOfUser.SystemEmployee)
                            await UserManager.AddToRoleAsync(user, RoleConstants.SystemEmployee);
                        else if ((TypeOfUser)user.TypeOfUser == TypeOfUser.ClientAdministrator)
                            await UserManager.AddToRoleAsync(user, RoleConstants.ClientAdministrator);
                    }
                }
            }
        }
    }
}
