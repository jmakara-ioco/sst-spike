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
    [Route("api/ContractTransactionDataFields")]
    [ApiController]
    public class ContractTransactionDataFieldController : VezaVIController<ContractTransactionDataField>
    {
        public ContractTransactionDataFieldController(ApplicationDbContext context) : base(context)
        {
        }
    }
}
