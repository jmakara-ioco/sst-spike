using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SST.Shared
{
    [Table("NonWorkingDays")]
    public class NonWorkingDay
    {
        [Column("ID")]
        public Guid ID { get; set; }

        [Column("UserID")]
        public Guid UserID { get; set; }

        [Column("FirmID")]
        public Guid FirmID { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Firm Firm { get; set; }
    }
}
