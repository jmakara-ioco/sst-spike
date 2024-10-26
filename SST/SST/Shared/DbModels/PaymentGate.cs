using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public enum PaymentSupplier
    {
        None,
        PayGate
    }

    public class PaymentGate : VezaVIGuidRecordBase
    {
        public bool EnableOnlineStore { get; set; } = false;
        public string APIKey { get; set; }
        public string APIPassword { get; set; }

        public int Supplier { get; set; } = (int)PaymentSupplier.PayGate;

        public Guid? FirmID { get; set; }
        [JsonIgnore]
        public Firm Firm { get; set; }

        public string OnlineStoreName { get; set; }

        public string UrlPrefects { get; set; }

    
    }
    
}
