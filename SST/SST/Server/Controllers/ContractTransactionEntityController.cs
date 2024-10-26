using Microsoft.AspNetCore.Mvc;
using SST.Server.Data;
using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VezaVI.Light.ServerExtensions;

namespace SST.Server
{
    [Route("api/ContractTransactionEntities")]
    [ApiController]
    public class ContractTransactionEntityController : VezaVIController<ContractTransactionEntity>
    {
        public ContractTransactionEntityController(ApplicationDbContext context) : base(context)
        {

        }
    }
}
