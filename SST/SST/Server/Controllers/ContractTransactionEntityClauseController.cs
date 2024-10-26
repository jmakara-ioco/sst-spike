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
    [Route("api/ContractTransactionEntityClauses")]
    [ApiController]
    public class ContractTransactionEntityClauseController : VezaVIController<ContractTransactionEntityClause>
    {
        public ContractTransactionEntityClauseController(ApplicationDbContext context) : base(context)
        {

        }
    }
}
