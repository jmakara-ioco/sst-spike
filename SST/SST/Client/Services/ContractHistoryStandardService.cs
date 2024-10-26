using Blazored.LocalStorage;
using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VezaVI.Light.Components;

namespace SST.Client.Services
{
    public class ContractHistoryStandardService : VezaDataService<ContractHistory>
    {
        public ContractHistoryStandardService(HttpClient httpClient,
                           ILocalStorageService localStorage) :
            base("api/ContractHistories", httpClient, localStorage)
        {
        }
    }
}
