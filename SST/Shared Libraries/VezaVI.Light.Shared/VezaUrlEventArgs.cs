using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Shared
{
    public partial class VezaUrlEventArgs : EventArgs
    {
        public VezaUrlEventArgs(string url)
        {
            Url = url;
        }

        public string Url { get; set; }
        public bool Cancel { get; set; } = false;
    }
}
