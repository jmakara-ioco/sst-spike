using System;
using System.Collections.Generic;
using System.Text;

namespace SST.Shared
{
    public class PDFToken
    {
        public string Content { get; set; }
        public Dictionary<int, string> HeadersAndFooters { get; set; } = new Dictionary<int, string>();
    }
}
