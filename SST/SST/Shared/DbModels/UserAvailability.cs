using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SST.Shared
{
    public class UserAvailability
    {
        [Column("ID")]
        public Guid ID { get; set; }

        [Column("UserID")]
        public Guid UserID { get; set; }

        [Column("DayID")]
        public Guid DayID { get; set; }

        [Column("TimeSlotID")]
        public Guid TimeSlotID { get; set; }

        [Column("Availability")]
        public int Availability { get; set; }

        public virtual TimeSlot TimeSlot { get; set; }
        public virtual Day Day { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
