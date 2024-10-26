using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class ContractQuestionIgnoredContractClause : VezaVIGuidRecordBase
    {
        public Guid QuestionID { get; set; }
        public ContractQuestion Question { get; set; }

        public Guid ContractClauseID { get; set; }
        public ContractClause ContractClause { get; set; }
    }
}
