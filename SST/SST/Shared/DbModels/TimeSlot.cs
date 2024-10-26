using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SST.Shared
{
    [Table("TimeSlot")]
    public class TimeSlot
    {
        [Column("ID")]
        public Guid ID { get; set; }

        [Column("StartTime")]
        public DateTime StartTime { get; set; }

        [Column("EndTime")]
        public DateTime EndTime { get; set; }
    }
}
