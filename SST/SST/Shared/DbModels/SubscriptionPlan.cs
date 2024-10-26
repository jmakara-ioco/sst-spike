using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class SubscriptionPlan : VezaVIGuidRecordBase
    {
        public string Description { get; set; }
        public int MaxUsers { get; set; }
        public double MonthlyPrice { get; set; }
        public double YearlyPrice { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDefaultPlan { get; set; } = false;
        public int ValidForDays { get; set; }
    }
}
