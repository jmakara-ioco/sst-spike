using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace SST.Shared
{
    public class SubscriptionToken
    {
        public int Users { get; set; }
        public string Frequency { get; set; }
        public double Amount { get; set; }
    }
}
