using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace SST.Client
{
    public class QuestionSimulationDisplayService : IQuestionSimulationDisplayService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public QuestionSimulationDisplayService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<QuestionSimulationDisplayModel> GetByID(Guid id)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.GetAsync($"api/GetContractSummary/{id}");
            var profileResult = JsonSerializer.Deserialize<QuestionSimulationDisplayModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return profileResult;
        }
    }
}
