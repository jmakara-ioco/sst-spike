using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class IntroStep : VezaVIGuidRecordBase
    {
        public string StepName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ButtonText { get; set; }
        public int Sequence { get; set; }
        public bool AllowSkip { get; set; } = true;
    }
}
