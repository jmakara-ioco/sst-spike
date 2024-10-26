using System;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class ContractQuestionAnswerIgnoredClause : VezaVIGuidRecordBase
    {
        public Guid AnswerID { get; set; }
        public ContractQuestionAnswer Answer { get; set; }

        public Guid ContractClauseID { get; set; }
        public ContractClause ContractClause { get; set; }
    }
}
