using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    [Table("Screens")]
    public class Screen : VezaVIGuidRecordBase
    {
        [Column("Name")]
        public string Name { get; set; }

        public List<ScreenField> ScreenFields { get; set; }
    }
}
