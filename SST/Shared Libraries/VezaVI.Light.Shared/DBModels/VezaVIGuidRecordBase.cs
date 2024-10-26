using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Shared
{
    public class VezaVIGuidRecordBase : IVezaVIRecordBase
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public Guid GetID()
        {
            return ID;
        }
    }
}
