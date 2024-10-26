using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SST.Client
{
    public interface IAutomaticMeetingService
    {
        Task<AutomaticMeetingSetupModel> GetFirmMeetingSetup();
        Task<ScreenSubmitResult> UpdateFirmMeetingSetup(AutomaticMeetingSetupModel AutomaticMeetingModel);
    }
}
