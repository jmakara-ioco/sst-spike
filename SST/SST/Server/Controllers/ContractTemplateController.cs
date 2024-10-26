using Microsoft.AspNetCore.Mvc;
using SST.Server.Data;
using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VezaVI.Light.ServerExtensions;
using VezaVI.Light.Shared;

namespace SST.Server
{
    [Route("api/ContractTransactionTemplates")]
    [ApiController]
    public class ContractTransactionTemplateController : VezaVIController<ContractTransactionTemplate>
    {
        public ContractTransactionTemplateController(ApplicationDbContext context) : base(context)
        {
        }
             public async override Task<VezaAPISubmitResult> Delete(string id)
        {

            try
            {
                var item = await _context.Set<ContractTransactionTemplate>().FindAsync(new Guid(id));
                if (item == null)
                {
                    return VezaAPISubmitResult.Failed("Could not locate record.");
                }
                item.IsActive = false;
                await _context.SaveChangesAsync();

                return VezaAPISubmitResult.Succeeded(item.GetID());
            }
            catch (Exception ex)
            {
                return VezaAPISubmitResult.Failed(ex.Message);

            }

        }

    }
}

