using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    [Table("Fields")]
    public class Field : VezaVIGuidRecordBase
    {
        [Column("FieldName")]
        public string FieldName { get; set; }

        [Column("ControlType")]
        public string ControlType { get; set; }

        [Column("Required")]
        public bool Required { get; set; }

        [Column("NullText")]
        public string NullText { get; set; }
        public Guid FirmID { get; set; }

        public List<ScreenField> ScreenFields { get; set; }
    }
}
