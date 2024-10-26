using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class ContractTransactionTemplate : VezaVIGuidRecordBase
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public bool IsActive { get; set; } = true;
        public Guid ContractTransactionID { get; set; }
        [JsonIgnore]
        public ContractTransaction ContractTransaction { get; set; }
    }
}
