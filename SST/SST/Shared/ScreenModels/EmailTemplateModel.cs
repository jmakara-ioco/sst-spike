using System;
using System.Collections.Generic;
using System.Text;

namespace SST.Shared
{
    public class EmailTemplateModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string HeaderBase64 { get; set; }
        public string FooterBase64 { get; set; }
        public string Body { get; set; }
    }
}
