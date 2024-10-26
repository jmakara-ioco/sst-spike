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
    [Route("api/ContractQuestionIgnoredContractClauses")]
    [ApiController]
    public class ContractQuestionIgnoredContractClauseController : VezaVIController<ContractQuestionIgnoredContractClause>
    {
        public ContractQuestionIgnoredContractClauseController(ApplicationDbContext context) : base(context)
        {

        }
    }
}
