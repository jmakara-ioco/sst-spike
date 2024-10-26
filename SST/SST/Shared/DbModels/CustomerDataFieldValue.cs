using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class CustomerDataFieldValue : VezaVIGuidRecordBase
    {
        public Guid CustomerDataFieldID { get; set; }
        public CustomerDataField CustomerDataField { get; set; }
        public Guid CustomerID { get; set; }
        public Customer Customer { get; set; }
        public string Value { get; set; }
    }
}
