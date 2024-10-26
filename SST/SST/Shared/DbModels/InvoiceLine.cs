using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class InvoiceLine : VezaVIGuidRecordBase
    {
        public Guid InvoiceID { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double DiscountPercentage { get; set; } = 0;

        public double GetTotalPrice()
        {
            return (Price * Quantity) * ((100 - DiscountPercentage) / 100);
        }
    }
}
