using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class ContractTransactionEntityClause : VezaVIGuidRecordBase
    {
        public Guid ContractTransactionEntityID { get; set; }
        public ContractTransactionEntity ContractTransactionEntity { get; set; }
        public string Code { get; set; }
        public string ClauseText { get; set; }
    }
}
