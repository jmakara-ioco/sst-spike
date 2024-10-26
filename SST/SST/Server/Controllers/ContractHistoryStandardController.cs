using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SST.Server.Data;
using SST.Shared;
using VezaVI.Light.ServerExtensions;

namespace SST.Server
{
    [Route("api/ContractHistories")]
    [ApiController]
    public class ContractHistoryStandardController : VezaVIController<ContractHistory>
    {
        public ContractHistoryStandardController(ApplicationDbContext context) : base(context)
        {

        }
    }
}
