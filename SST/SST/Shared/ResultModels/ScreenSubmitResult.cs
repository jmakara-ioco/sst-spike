using System;
using System.Collections.Generic;
using System.Text;

namespace SST.Shared
{
    public class ScreenSubmitResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
