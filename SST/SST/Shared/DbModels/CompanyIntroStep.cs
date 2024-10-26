using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class FirmIntroStep : VezaVIGuidRecordBase
    {
        public Guid FirmID { get; set; }
        public Firm Firm { get; set; }
        public Guid IntroStepID { get; set; }
        public IntroStep IntroStep { get; set; }
    }
}
