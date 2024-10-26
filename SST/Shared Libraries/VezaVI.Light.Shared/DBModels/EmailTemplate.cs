using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VezaVI.Light.Shared
{
    [Table("EmailTemplates")]
    public class EmailTemplate : VezaVIGuidRecordBase
    {
        [Column("Name")]
        public string Name { get; set; }

        [Column("Subject")]
        public string Subject { get; set; }

        public virtual List<EmailTemplateElement> EmailTemplateElements { get; set; }
    }
}
