using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SST.Server.Data;
using SST.Shared;
using VezaVI.Light.ServerExtensions;
using VezaVI.Light.Shared;

namespace SST.Server.Controllers
{
    [Route("api/FirmStylings")]
    [ApiController]
    public class FirmStylingController : VezaVIController<FirmStyling>
    {
        public FirmStylingController(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<VezaAPISubmitResult> Post([FromBody] FirmStyling item)
        {
            return base.Post(item);
        }
    }
}
