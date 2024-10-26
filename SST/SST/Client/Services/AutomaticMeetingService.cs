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
    public class AutomaticMeetingService : IAutomaticMeetingService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AutomaticMeetingService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }
        public async Task<AutomaticMeetingSetupModel> GetFirmMeetingSetup()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.GetAsync("api/GetFirmMeetingSetup");
            var result = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(result))
                return JsonSerializer.Deserialize<AutomaticMeetingSetupModel>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return null;
        }

        public async Task<ScreenSubmitResult> UpdateFirmMeetingSetup(AutomaticMeetingSetupModel AutomaticMeetingModel)
        {
            var meetingSettingsAsJson = JsonSerializer.Serialize(AutomaticMeetingModel);
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.PostAsync("api/UpdateFirmMeetingSetup", new StringContent(meetingSettingsAsJson, Encoding.UTF8, "application/json"));
            var profileResult = JsonSerializer.Deserialize<ScreenSubmitResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return profileResult;
        }
    }
}
