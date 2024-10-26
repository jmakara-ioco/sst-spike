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
    public class ContractHistoryService : IContractHistoryService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public ContractHistoryService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<List<ContractHistory>> GetFirmContracts(Guid FirmID)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.GetAsync($"api/GetFirmContracts/{FirmID}");
            var result = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(result))
                return JsonSerializer.Deserialize<List<ContractHistory>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return new List<ContractHistory>();
        }

        public async Task<VezaAPISubmitResult> UpdateContentJson(QuestionSimulation contentAsJson)
        {
            var content = JsonSerializer.Serialize(contentAsJson);
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.PostAsync("api/UpdateContentJson", new StringContent(content, Encoding.UTF8, "application/json"));
            var responseText = await response.Content.ReadAsStringAsync();
            var firmResult = JsonSerializer.Deserialize<VezaAPISubmitResult>(responseText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, IgnoreNullValues = false }); ;
            return firmResult;
        }
    }
}
