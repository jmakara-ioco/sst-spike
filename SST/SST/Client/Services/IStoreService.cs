using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SST.Client
{
    public interface IStoreService
    {
        Task<ScreenSubmitResult> UpdateStoreUser(StoreModel storeModel);
        public Task<StoreModel> GetStoreUser();

    }
}
