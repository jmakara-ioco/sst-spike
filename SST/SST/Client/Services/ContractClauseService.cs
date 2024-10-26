using Blazored.LocalStorage;
using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VezaVI.Light.Components;

namespace SST.Client
{
    public class ContractClauseService : VezaDataService<ContractClause>
    {
        public ContractClauseService(HttpClient httpClient,
                           ILocalStorageService localStorage) :
            base("api/ContractClauses", httpClient, localStorage)
        {
        }
    }
}
