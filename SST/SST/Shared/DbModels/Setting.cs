using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    [Table("Settings")]
    public class Setting : VezaVIGuidRecordBase
    {
        [Column("Name")]
        public string Name { get; set; }

        [Column("Value")]
        public string Value { get; set; }
    }
}
