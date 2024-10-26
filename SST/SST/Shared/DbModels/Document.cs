using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    [Table("Documents")]
    public class Document : VezaVIGuidRecordBase
    {
        [Column("DisplayName")]
        public string Name { get; set; }

        [Column("FileName")]
        public string FileName { get; set; }

        [Column("DocumentTypeID")]
        public Guid DocumentTypeID { get; set; }

        public virtual DocumentType DocumentType { get; set; }

        public List<FirmDocument> FirmDocuments { get; set; }

        public List<CustomerDocument> CustomerDocuments { get; set; }
    }
}
