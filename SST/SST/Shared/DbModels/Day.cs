using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SST.Shared
{
    [Table("Day")]
    public class Day
    {
        [Column("ID")]
        public Guid ID { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("DayOfWeek")]
        public DayOfWeek DayOfWeek { get; set; }

        public List<UserAvailability> UserAvailabilities { get; set; }
        public List<MeetingTimeSlot> MeetingTimeSlots { get; set; }
    }
}
