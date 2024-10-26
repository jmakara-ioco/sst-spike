using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class Country : VezaVIGuidRecordBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ISO2 { get; set; }
        [Required]
        public string DailingCode { get; set; }
    }
}
