using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class ContractClause : VezaVIGuidRecordBase
    {
        public string Code { get; set; }
        public Guid FirmID { get; set; }
        public Firm Firm { get; set; }
        public Guid? ContractTransactionID { get; set; }
        public ContractTransaction ContractTransaction { get; set; }
        public string ClauseText { get; set; } = string.Empty;

    }
}
