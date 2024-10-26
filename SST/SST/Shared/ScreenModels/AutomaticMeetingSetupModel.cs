using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SST.Shared
{
    public class AutomaticMeetingSetupModel
    {
        [Required]
        public bool AllowMeetings { get; set; }

        [Required]
        public bool AllowPhysical { get; set; }

        [Required]
        public bool AllowElectronicMeetings { get; set; }

        [Required]
        public bool AllowPublicHolidays { get; set; }
    }
}
