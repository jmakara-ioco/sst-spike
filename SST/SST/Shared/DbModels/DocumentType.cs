using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    [Table("DocumentTypes")]
    public class DocumentType : VezaVIGuidRecordBase
    {
        [Column("Name")]
        public string Name { get; set; }

        public List<Document> Documents { get; set; }
    }
}
