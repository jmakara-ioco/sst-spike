using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VezaVI.Light.Shared
{
    [Table("EmailTemplateElements")]
    public class EmailTemplateElement : VezaVIGuidRecordBase
    {
        [Column("EmailTemplateID")]
        public Guid EmailTemplateID { get; set; }
        public EmailTemplate EmailTemplate { get; set; }

        [Column("Sort")]
        public int Sort { get; set; }
        [Column("ElementType")]
        public string ElementType { get; set; }
        [Column("ElementConfig")]
        public string ElementConfig { get; set; }
        [Column("ElementText")]
        public string ElementText { get; set; }
    }
}
