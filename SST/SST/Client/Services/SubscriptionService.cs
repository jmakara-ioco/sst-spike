using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VezaVI.Light.Shared;

namespace SST.Client
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public SubscriptionService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public bool IsActive
        {
            get
            {
                if ((SubscriptionPlan != null) && (SubscriptionPlan.ExpiryDate > DateTime.UtcNow))
                    return true;
                return false;
            }
        }

        public int MaxUsers
        {
            get
            {
                if (SubscriptionPlan != null)
                    return SubscriptionPlan.NrOFUsers;
                return 1;
            }
        }

        private FirmSubscriptionPlan _plan;

        public event EventHandler Changed;
        protected virtual void OnChanged(EventArgs e)
        {
            Changed?.Invoke(this, e);
        }


        public FirmSubscriptionPlan SubscriptionPlan
        {
            get
            {
                return _plan;
            }
        }

        public async Task<FirmSubscriptionPlan> GetActivePlan()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.GetAsync("api/ActivePlan");
            _plan = JsonSerializer.Deserialize<FirmSubscriptionPlan>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return _plan;
        }

        public async Task ActivateNow()
        {
            _plan = new FirmSubscriptionPlan()
            {
                ExpiryDate = DateTime.UtcNow.Add(new TimeSpan(100, 0, 0, 0)),
                Description = "System User",
                NrOFUsers = 200
            };
            OnChanged(EventArgs.Empty);
        }

        public async Task<VezaAPISubmitResult> GenerateInvoice(SubscriptionToken token)
        {
            var loginAsJson = JsonSerializer.Serialize(token);
            var response = await _httpClient.PostAsync("api/GenerateSubscriptionInvoice", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            var loginResult = JsonSerializer.Deserialize<VezaAPISubmitResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return loginResult;
        }

        public async Task<InvoiceHeader> GetInvoice(Guid id)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.GetAsync($"api/GetInvoice/{id}");
            var invoiceResult = JsonSerializer.Deserialize<InvoiceHeader>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return invoiceResult;
        }
    }
}
