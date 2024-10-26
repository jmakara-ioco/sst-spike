using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    [Table("FirmDocuments")]
    public class FirmDocument : VezaVIGuidRecordBase
    {
        [Column("FirmID")]
        public Guid FirmID { get; set; }

        [Column("DocumentID")]
        public Guid DocumentID { get; set; }

        public virtual Firm Firm { get; set; }

        public virtual Document Document { get; set; }
    }
}
