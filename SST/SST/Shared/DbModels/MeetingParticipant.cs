using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SST.Shared
{
    [Table("MeetingParticipants")]
    public class MeetingParticipant
    {
        [Column("ID")]
        public Guid ID { get; set; }

        [Column("MeetingID")]
        public Guid MeetingID { get; set; }

        [Column("UserID")]
        public Guid UserID { get; set; }

        public virtual Meeting Meeting { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
