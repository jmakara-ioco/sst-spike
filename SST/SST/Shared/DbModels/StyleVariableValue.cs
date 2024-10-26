using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    [Table("StyleVariableValues")]
    public class StyleVariableValue : VezaVIGuidRecordBase
    {
        [Column("VariableID")]
        public Guid VariableID { get; set; }

        [Column("VariableValue")]
        public string VariableValue { get; set; }

        [Column("FirmID")]
        public Guid FirmID { get; set; }

        public virtual StyleVariable StyleVariable { get; set; }
        public virtual Firm Firm { get; set; }
    }
}
