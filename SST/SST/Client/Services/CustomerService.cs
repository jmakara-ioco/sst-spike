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
    public class CustomerService : VezaDataService<Customer>
    {
        public CustomerService(HttpClient httpClient,
                           ILocalStorageService localStorage) :
            base("api/Customers", httpClient, localStorage)
        {
        }
    }
}
