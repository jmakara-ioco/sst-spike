using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class EmailTemplate : VezaVIGuidRecordBase
    {
        public Guid FirmID { get; set; }
        public Firm Firm { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Subject")]
        public string Subject { get; set; }

        [Column("Body")]
        public string Body { get; set; }

        [Column("HeaderImage")]
        public string HeaderImage { get; set; }

        [Column("FooterImage")]
        public string FooterImage { get; set; }
    }
}
