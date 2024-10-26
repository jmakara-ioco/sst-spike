using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SST.Shared
{
    [Table("Meetings")]
    public class Meeting
    {
        [Column("ID")]
        public Guid ID { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("Description")]
        public string Deescription { get; set; }

        [Column("OwnerUserID")]
        public Guid OwnerUserID { get; set; }

        public virtual ApplicationUser OwnerUser { get; set; }
    }
}
