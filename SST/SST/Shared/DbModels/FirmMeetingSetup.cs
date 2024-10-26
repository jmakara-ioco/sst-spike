using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    [Table("FirmMeetingSetup")]
    public class FirmMeetingSetup : VezaVIGuidRecordBase
    {
        [Column("FirmID")]
        public Guid FirmID { get; set; }

        [Column("AllowMeetings")]
        public bool AllowMeetings { get; set; }

        [Column("AllowPhysical")]
        public bool AllowPhysical { get; set; }

        [Column("AllowElectrical")]
        public bool AllowElectrical { get; set; }

        [Column("AllowPublicHolidays")]
        public bool AllowPublicHolidays { get; set; }

        public virtual Firm Firm { get; set; }
    }
}
