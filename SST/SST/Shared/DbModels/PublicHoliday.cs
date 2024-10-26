using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SST.Shared
{
    [Table("PublicHolidays")]
    public class PublicHoliday
    {
        [Column("ID")]
        public Guid ID { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("FirmID")]
        public Guid FirmID { get; set; }

        public virtual Firm Firm { get; set; }

    }
}
