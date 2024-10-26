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
    [Route("api/ContractQuestionTemplates")]
    [ApiController]
    public class ContractQuestionTemplateController : VezaVIController<ContractQuestionTemplate>
    {        
        public ContractQuestionTemplateController(ApplicationDbContext context) : base(context)
        {

        }
        public override Task<VezaAPISubmitResult> Post([FromBody] ContractQuestionTemplate item)
        {
            var contractQuestionTemplates = _context.Set<ContractQuestionTemplate>().Where(x => x.QuestionID == item.QuestionID);
            var nextNum = (contractQuestionTemplates.Count() > 0) ? contractQuestionTemplates.Max(x => x.SequenceNumber) +1 : 1;
            item.SequenceNumber = nextNum;
            return base.Post(item);
        }
    }
}
