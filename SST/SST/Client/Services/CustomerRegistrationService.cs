using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SST.Client
{
    public class CustomerRegistrationService : ICustomRegistrationService
    {
        public HttpClient _httpClient;

        public CustomerRegistrationService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<ScreenSubmitResult> RegisterCustomer(CustomerRegisterModel customerRegisterModel)
        {
            try
            {
                var loginAsJson = JsonSerializer.Serialize(customerRegisterModel);
                var response = await _httpClient.PostAsync("api/createinviteemail", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
                var loginResult = JsonSerializer.Deserialize<ScreenSubmitResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return loginResult;
            }
            catch (Exception ex)
            {
                return null;


            }
        }
    }
}
