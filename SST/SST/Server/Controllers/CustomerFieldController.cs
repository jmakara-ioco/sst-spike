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
    [Route("api/CustomerFields")]
    [ApiController]
    public class CustomerFieldController : VezaVIController<Field>
    {
        public CustomerFieldController(ApplicationDbContext context) : base(context)
        {

        }
    }
}
