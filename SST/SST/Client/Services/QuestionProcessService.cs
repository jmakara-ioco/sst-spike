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

namespace SST.Client
{
    public class QuestionProcessService : IQuestionProcessService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public QuestionProcessService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<QuestionAnswerResult> FindQuestionToShow(CurrentQuestionModel currentQuestionModel)
        {
            var questionAsJson = JsonSerializer.Serialize(currentQuestionModel);
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.PostAsync("api/GetNextQuestion", new StringContent(questionAsJson, Encoding.UTF8, "application/json"));
            var questionResult = JsonSerializer.Deserialize<QuestionAnswerResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return questionResult;
        }

        public async Task<QuestionToken> GetQuestion(Guid id)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.GetAsync($"api/GetQuestion/{id}");
            var questionResult = JsonSerializer.Deserialize<QuestionToken>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return questionResult;
        }

        public async Task<QuestionToken> GetRootQuestion(Guid transactionID)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.GetAsync($"api/GetFirtsQuestion/{transactionID}");
            var questionResult = JsonSerializer.Deserialize<QuestionToken>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return questionResult;
        }
    }
}
