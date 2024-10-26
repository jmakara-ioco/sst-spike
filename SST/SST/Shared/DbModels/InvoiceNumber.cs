using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class InvoiceNumber : VezaVIGuidRecordBase
    {
        public Guid FirmID { get; set; }
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
                InvNumber = "INV" + value.ToString().PadLeft(10, '0');
            }
        }
        public bool Used { get; set; }


        private string _invNumber;
        public string InvNumber
        {
            get
            {
                return _invNumber;
            }
            set
            {
                _invNumber = value;
            }
        }
       
    }
}
