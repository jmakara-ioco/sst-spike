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
    public class MailService : IMailService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public MailService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<ScreenSubmitResult> UpdateMailSettings(EmailSettingModel mailModel)
        {
            var mailSettingAsJson = JsonSerializer.Serialize(mailModel);
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.PostAsync("api/UpdateMailSettings", new StringContent(mailSettingAsJson, Encoding.UTF8, "application/json"));
            var mailResult = JsonSerializer.Deserialize<ScreenSubmitResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return mailResult;
        }
    }
}
