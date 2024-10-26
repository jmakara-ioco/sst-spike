using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class ContractTransactionDataField : VezaVIGuidRecordBase
    {
        public int TypeOfField { get; set; } = (int)DataFieldType.Text;
        public string FieldName { get; set; }
        public string DisplayText { get; set; }
        public Guid ContractTransactionID { get; set; }
        public ContractTransaction ContractTransaction { get; set; }
    }
}
