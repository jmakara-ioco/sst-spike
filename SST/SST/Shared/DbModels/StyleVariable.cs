using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    [Table("StyleVariables")]
    public class StyleVariable : VezaVIGuidRecordBase
    {
        [Column("Name")]
        public string Name { get; set; }

        public List<StyleVariableValue> StyleVariableValues { get; set; }
    }
}
