using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SST.Shared
{
    [Table("MeetingTimeSlots")]
    public class MeetingTimeSlot
    {
        [Column("ID")]
        public Guid ID { get; set; }

        [Column("MeetingID")]
        public Guid MeetingID { get; set; }

        [Column("TimeSlotID")]
        public Guid TimeSlotID { get; set; }

        [Column("DayID")]
        public Guid DayID { get; set; }

        public virtual Day Day { get; set; }

        public virtual TimeSlot TimeSlot { get; set; }

        public virtual Meeting Meeting { get; set; }
    }
}
