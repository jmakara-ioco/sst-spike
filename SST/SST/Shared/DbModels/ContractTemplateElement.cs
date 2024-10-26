using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class ContractTemplateElement : VezaVIGuidRecordBase
    {
        public Guid ContractTransactionTemplateID { get; set; }
        public ContractTransactionTemplate ContractTransactionTemplate { get; set; }
        public string TemplateText { get; set; } = string.Empty;
    }
}
