using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Shared
{
    public partial class VezaPathNodeClickEvent : EventArgs
    {
        public VezaPathNodeClickEvent(VezaPathNode node)
        {
            Node = node;
        }
        public VezaPathNode Node { get; set; }

    }
}
