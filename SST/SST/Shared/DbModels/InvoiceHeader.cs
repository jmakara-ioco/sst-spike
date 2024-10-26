using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class InvoiceHeader : VezaVIGuidRecordBase
    {
        public DateTime InvoiceDate { get; set; }
        public Guid FirmID { get; set; }
        public Firm Firm { get; set; }

        public string Currency { get; set; }
        public string InvoicedTo { get; set; }

        public int NrOfUsers { get; set; }
        public string BillingFrequency { get; set; }

        private int _sequence;
        public int Sequence
        {
            get
            {
                return _sequence;
            }
            set
            {
                _sequence = value;
                InvoiceNumber = "INV" + value.ToString().PadLeft(10, '0');
            }
        }
        public string TransactionNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public int Status { get; set; } = 0;

        public List<InvoiceLine> Lines { get; set; } = new List<InvoiceLine>();

        public double GetTotalPrice()
        {
            return Lines.Where (x => x != null).Sum(t => t.GetTotalPrice());
        }

        public string GetFormattedTotalPrice()
        {
            return $"{Currency} {GetTotalPrice().ToString("f2")}";
        }

    }
}
