using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class CustomerDataField : VezaVIGuidRecordBase
    {
        public DataFieldType TypeOfField { get; set; } = (int)DataFieldType.Text;
        public string FieldName { get; set; }
        public string DisplayText { get; set; }
        public bool Required { get; set; }
        public string NullText { get; set; }
        public Guid FirmID { get; set; }
        public Firm Firm { get; set; }
    }
}