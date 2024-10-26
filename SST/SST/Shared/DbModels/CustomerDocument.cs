using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    [Table("CustomerDocuments")]
    public class CustomerDocument : VezaVIGuidRecordBase
    {
        [Column("CustomerID")]
        public Guid CustomerID { get; set; }

        [Column("DocumentID")]
        public Guid DocumentID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Document Document { get; set; }
    }
}
