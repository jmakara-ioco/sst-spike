// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace 
#nullable restore
#line 8 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\FirmProfile.razor"
           SST.Client

#line default
#line hidden
#nullable disable
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using System.Net.Http

#nullable disable
    ;
#nullable restore
#line 2 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using System.Net.Http.Json

#nullable disable
    ;
#nullable restore
#line 3 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization

#nullable disable
    ;
#nullable restore
#line 4 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms

#nullable disable
    ;
#nullable restore
#line 5 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing

#nullable disable
    ;
#nullable restore
#line 6 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web

#nullable disable
    ;
#nullable restore
#line 7 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http

#nullable disable
    ;
#nullable restore
#line 8 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Microsoft.JSInterop

#nullable disable
    ;
#nullable restore
#line 9 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using SST.Client

#nullable disable
    ;
#nullable restore
#line 10 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using SST.Client.Shared

#nullable disable
    ;
#nullable restore
#line 11 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using SST.Shared

#nullable disable
    ;
#nullable restore
#line 12 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization

#nullable disable
    ;
#nullable restore
#line 13 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using System.Text.Json

#nullable disable
    ;
#nullable restore
#line 14 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Blazored.LocalStorage

#nullable disable
    ;
#nullable restore
#line 15 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using System.Net.Http.Headers

#nullable disable
    ;
#nullable restore
#line 16 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Microsoft.AspNetCore.Identity

#nullable disable
    ;
#nullable restore
#line 17 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using VezaVI.Light.Components

#nullable disable
    ;
#nullable restore
#line 18 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using VezaVI.Light.Shared

#nullable disable
    ;
#nullable restore
#line 19 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Blazored.Modal

#nullable disable
    ;
#nullable restore
#line 20 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Blazored.Modal.Services

#nullable disable
    ;
#nullable restore
#line 21 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using System.Security.Claims

#nullable disable
    ;
#nullable restore
#line 22 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using System.IO

#nullable disable
    ;
#nullable restore
#line 23 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using SixLabors.ImageSharp

#nullable disable
    ;
#nullable restore
#line 24 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using SixLabors.ImageSharp.Processing

#line default
#line hidden
#nullable disable
    ;
#nullable restore
#line 7 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\FirmProfile.razor"
           [Microsoft.AspNetCore.Authorization.Authorize(Roles = RoleConstants.FirmAdministrator)]

#line default
#line hidden
#nullable disable

    [global::Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [global::Microsoft.AspNetCore.Components.RouteAttribute(
    // language=Route,Component
#nullable restore
#line 1 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\FirmProfile.razor"
      "/firmprofile"

#line default
#line hidden
#nullable disable
    )]
    #nullable restore
    public partial class FirmProfile : global::Microsoft.AspNetCore.Components.ComponentBase
    #nullable disable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 50 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\FirmProfile.razor"
       

    private FirmModel firmModel = new FirmModel() { Address = new Address() };
    private bool ShowErrors;
    private string Error = "";

    protected async override Task OnInitializedAsync()
    {
        await Load();
    }

    private async Task Load()
    {
        var tokenResult = await LocalStorage.GetItemAsync<string>("authToken");
        var request = new HttpRequestMessage(HttpMethod.Get, $"api/GetFirmProfile");
        request.Headers.Authorization = new AuthenticationHeaderValue("bearer", tokenResult);
        var response = await HttpClient.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var resultstr = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(resultstr))
            {
                firmModel = JsonSerializer.Deserialize<FirmModel>(resultstr, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                StateHasChanged();
            }
        }
    }

    private async Task Update()
    {
        ShowErrors = false;

        var result = await FirmService.UpdateFirmSettings(firmModel);

        if (result.Successful)
        {
            NavigationManager.NavigateTo("/");
        }
        else
        {
            Error = result.Errors.FirstOrDefault();
            ShowErrors = true;
        }
    }


#line default
#line hidden
#nullable disable

        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 6 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\FirmProfile.razor"
        IFirmService

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 6 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\FirmProfile.razor"
                     FirmService

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 5 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\FirmProfile.razor"
        HttpClient

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 5 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\FirmProfile.razor"
                   HttpClient

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 4 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\FirmProfile.razor"
        ILocalStorageService

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 4 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\FirmProfile.razor"
                             LocalStorage

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 2 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\FirmProfile.razor"
        NavigationManager

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 2 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\FirmProfile.razor"
                          NavigationManager

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
    }
}
#pragma warning restore 1591
