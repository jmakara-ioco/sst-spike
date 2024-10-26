using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using VezaVI.Light.Components;
using VezaVI.Light.Shared;

namespace SST.Client
{
    public class TenantHelperService : ITenantHelperService
    {
        Dictionary<string, Guid> _tenants = new Dictionary<string, Guid>();
        private readonly NavigationManager _navigationManager;
        private readonly IVezaDataService<FirmStyling> _firmStylingService;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public TenantHelperService(NavigationManager navigationManager, AuthenticationStateProvider authenticationStateProvider, IVezaDataService<FirmStyling> firmStylingService, HttpClient httpClient)
        {
            _navigationManager = navigationManager;
            _firmStylingService = firmStylingService;
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<Guid> GetTenant()
        {
            string tenant = _navigationManager.BaseUri.Replace("https://","");
            string tenantSegment = string.Empty;
            
            if (tenant.Contains('.'))
                tenantSegment = tenant.Substring(0, tenant.IndexOf('.'));
            Console.WriteLine(tenantSegment);
            Guid retGuid = Guid.Empty;
            if (!string.IsNullOrEmpty(tenantSegment))
            {
                var response = await _httpClient.GetAsync($"api/GetTenantBySegment/{tenantSegment}");
                retGuid = JsonSerializer.Deserialize<Guid>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            if (retGuid == Guid.Empty)
            {
                var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
                if (state != null) {
                    var tenantClaim = state.User.Claims.FirstOrDefault(x => x.Type == "CompanyID");
                    if (tenantClaim != null)
                    {
                        retGuid = new Guid(tenantClaim.Value);
                    }
                }
            }
            return retGuid;
        }

        public void ValidateTenant()
        {
            /*if ((_navigationManager.Uri != "https://test.localhost:44323/") && (_navigationManager.Uri != "https://localhost:44323/"))
                _navigationManager.NavigateTo("/incorrectdomain");*/
        }

        private FirmStyling _firmStyling;
        private DateTime? timeStamp = null;
        public async Task<FirmStyling> GetBranding(Guid firmID)
        {
            /*if ((timeStamp == null) || (timeStamp.Value.AddHours(1) < DateTime.Now))
            {*/
                var pagedFirmStyling = await _firmStylingService.GetAllAsync("ID", new List<VezaVIGridFilter>() {
                    new VezaVIGridFilter() { 
                         Field = "FirmID", Value = firmID.ToString(), Equals = true 
                    }
                });
                if ((pagedFirmStyling.Items == null) && (pagedFirmStyling.Items.Count == 0))
                    _firmStyling = new FirmStyling();
                else
                {
                    _firmStyling = pagedFirmStyling.Items.FirstOrDefault();
                }
                //timeStamp = DateTime.Now;
                return _firmStyling;
            /*}
            else
                return _firmStyling;*/
        }

        public async Task ResetBranding()
        {
            timeStamp = null;
        }

        public async Task<List<string>> GetAllFonts()
        {
            var response = await _httpClient.GetAsync("api/GetAllFonts");
            var result = JsonSerializer.Deserialize<List<string>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result;
        }

        public async Task<StoreModel> GetStoreInfo(Guid firmID)
        {
            var response = await _httpClient.GetAsync($"api/GetStoreInfo/{firmID}");
            var result = JsonSerializer.Deserialize<StoreModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result;
        }
    }
}
