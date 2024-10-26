using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SST.Shared
{
    public class FirmModel
    {
        [Required]
        public string FirmName { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        public string VatNumber { get; set; }
        public Address Address { get; set; }
    }
}
