using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class ContractClauseElement : VezaVIGuidRecordBase
    {
        public Guid ContractClauseID { get; set; }
        public ContractClause ContractClause { get; set; }

        public string ElementType { get; set; }
        public string ElementText { get; set; } = string.Empty;
        public string ElementConfig { get; set; } = string.Empty;
    }
}
