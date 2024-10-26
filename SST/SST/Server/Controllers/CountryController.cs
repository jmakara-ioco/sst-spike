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
    [Route("api/Countries")]
    [ApiController]
    public class CountryController : VezaVIController<Country>
    {
        public CountryController(ApplicationDbContext context) : base(context)
        {

        }
    }
}
