using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class ContractTransactionEntityDataField : VezaVIGuidRecordBase
    {
        public int TypeOfField { get; set; } = (int)DataFieldType.Text;
        public string FieldName { get; set; }
        public string DisplayText { get; set; }
        public Guid ContractTransactionEntityID { get; set; }
        public ContractTransactionEntity ContractTransactionEntity { get; set; }
    }
}