using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Shared
{
    public class VezaMultiItem
    {
        public Guid Key { get; set; }
        public string DisplayText { get; set; }
        public int SequenceNumber { get; set; }
        public bool Selected { get; set; } = false;
        public string objectID { get; set; } = string.Empty;
    }
}
