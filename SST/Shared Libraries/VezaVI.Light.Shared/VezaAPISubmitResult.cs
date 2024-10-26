using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VezaVI.Light.Shared
{
    public class VezaAPISubmitResult
    {
        public object EntityID { get; set; }
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public object AdditionalValue { get; set; }

        public static VezaAPISubmitResult Succeeded(object id)
        {
            return new VezaAPISubmitResult() { Successful = true, EntityID = id };
        }

        public static VezaAPISubmitResult Failed(params string[] message)
        {
            return new VezaAPISubmitResult() { Successful = false, Errors = message.ToList() };
        }

        
    }
}
