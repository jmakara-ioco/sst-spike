using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class ContractTransactionEntity : VezaVIGuidRecordBase
    {
        public string Name { get; set; }
        public Guid ContractTransactionID { get; set; }
        public ContractTransaction ContractTransaction { get; set; }
    }
}
