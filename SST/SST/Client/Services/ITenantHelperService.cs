using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SST.Client
{
    public interface ITenantHelperService
    {
        Task<Guid> GetTenant();
        void ValidateTenant();
        Task<FirmStyling> GetBranding(Guid firmID);
        Task ResetBranding();
        Task<List<string>> GetAllFonts();

        Task<StoreModel> GetStoreInfo(Guid firmID);
    }
}
