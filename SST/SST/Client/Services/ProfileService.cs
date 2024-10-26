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
    public class ProfileService : IProfileService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public ProfileService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<ScreenSubmitResult> UpdateProfile(ProfileModel profileModel)
        {
            var profileAsJson = JsonSerializer.Serialize(profileModel);
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.PostAsync("api/UpdateProfile", new StringContent(profileAsJson, Encoding.UTF8, "application/json"));
            var profileResult = JsonSerializer.Deserialize<ScreenSubmitResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return profileResult;
        }

        public async Task<ProfileModel> GetProfile()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.GetAsync("api/GetUserProfile");
            var profileResult = JsonSerializer.Deserialize<ProfileModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return profileResult;
        }

        public async Task<ScreenSubmitResult> UpdatePassword(ChangePasswordModel changePasswordModel)
        {
            var passwordAsJson = JsonSerializer.Serialize(changePasswordModel);
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.PostAsync("api/ChangePassword", new StringContent(passwordAsJson, Encoding.UTF8, "application/json"));
            var passwordResult = JsonSerializer.Deserialize<ScreenSubmitResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return passwordResult;
        }

        public async Task<ScreenSubmitResult> RemovePassword(ForgotPasswordModel forgotPasswordModel)
        {
            var passwordAsJson = JsonSerializer.Serialize(forgotPasswordModel);
            var response = await _httpClient.PostAsync("api/ForgotPassword", new StringContent(passwordAsJson, Encoding.UTF8, "application/json"));
            var passwordResult = JsonSerializer.Deserialize<ScreenSubmitResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return passwordResult;
        }

        public async Task<ScreenSubmitResult> AddPassword(NewPasswordModel newPasswordModel)
        {
            var passwordAsJson = JsonSerializer.Serialize(newPasswordModel);
            var response = await _httpClient.PostAsync("api/NewPassword", new StringContent(passwordAsJson, Encoding.UTF8, "application/json"));
            var passwordResult = JsonSerializer.Deserialize<ScreenSubmitResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return passwordResult;
        }
    }
}
