using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    [Table("ScreenFields")]
    public class ScreenField : VezaVIGuidRecordBase
    {
        [Column("ScreenID")]
        public Guid ScreenID { get; set; }

        [Column("FieldID")]
        public Guid FieldID { get; set; }

        [Column("FirmID")]
        public Guid FirmID { get; set; }

        public virtual Screen Screen { get; set; }

        public virtual Field Field { get; set; }

        public virtual Firm Firm { get; set; }
    }
}
