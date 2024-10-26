using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class FirmSubscriptionPlan : VezaVIGuidRecordBase
    {
        public Guid InvoiceHeaderID { get; set; }
        public InvoiceHeader InvoiceHeader { get; set; }
        public Guid FirmID { get; set; }
        public Firm Firm { get; set; }

        public int NrOFUsers { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool AutoRenew { get; set; }
        public int AutoRenewOnDay { get; set; }
        [NotMapped]
        public string Description { get; set; }
    }
}
