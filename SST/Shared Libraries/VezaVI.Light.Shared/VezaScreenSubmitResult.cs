using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Shared
{
    public class VezaScreenSubmitResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors {  get; set; }
    }
}
