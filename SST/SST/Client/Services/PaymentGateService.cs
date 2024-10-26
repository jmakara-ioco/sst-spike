using Blazored.LocalStorage;
using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SST.Client.Services
{
    public class PaymentGateService : IPaymentGateService
    {

        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public PaymentGateService(HttpClient httpClient,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<PaymentGate> GetDefaultPaymentGate()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.GetAsync("api/DefaultPaymentGate");
            var result = JsonSerializer.Deserialize<PaymentGate>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result;
        }

        public async Task<ScreenSubmitResult> UpdateDefaultPaymentGate(PaymentGate model)
        {
            var mailSettingAsJson = JsonSerializer.Serialize(model);
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.PostAsync("api/DefaultPaymentGate", new StringContent(mailSettingAsJson, Encoding.UTF8, "application/json"));
            var result = JsonSerializer.Deserialize<ScreenSubmitResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result;
        }
    }
}
