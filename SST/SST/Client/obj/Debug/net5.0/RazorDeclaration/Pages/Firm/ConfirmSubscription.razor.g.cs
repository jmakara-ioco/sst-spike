// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SST.Client.Pages.Firm
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
    [global::Microsoft.AspNetCore.Components.RouteAttribute(
    // language=Route,Component
#nullable restore
#line 1 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\ConfirmSubscription.razor"
      "/confirmsubscription/{transactionID:guid}"

#line default
#line hidden
#nullable disable
    )]
    #nullable restore
    public partial class ConfirmSubscription : global::Microsoft.AspNetCore.Components.ComponentBase
    #nullable disable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 60 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\ConfirmSubscription.razor"
           

        [Parameter]
        public Guid transactionID { get; set; }

        private bool ShowErrors;
        private string Error = "";

        private int Users = 1;
        private string PaymentFrequency = "Monthly";
        private string VERSION = "21";
        private string PAYGATE_ID = "10011072130";
        private string REFERENCE = "";
        private string AMOUNT = "0";
        public string CURRENCY = "ZAR";
        public string RETURN_URL = "";
        public string EMAIL = "nando.mangels@gmail.com";
        public string TRANSACTION_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        public string SUBS_START_DATE = DateTime.Now.ToString("yyyy-MM-dd");
        public string SUBS_END_DATE = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
        public string SUBS_FREQUENCY = "228";
        public string PROCESS_NOW = "NO";
        public string PROCESS_NOW_AMOUNT = "";
        public string KEY = "secret";

        private Dictionary<string, string> PaymentOptions = new Dictionary<string, string>();
        private InvoiceHeader Invoice { get; set; }
        protected async override Task OnInitializedAsync()
        {
            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            Invoice = await SubscriptionService.GetInvoice(transactionID);
            Users = Invoice.NrOfUsers;
            PaymentFrequency = Invoice.BillingFrequency;
            var total = Invoice.GetTotalPrice();
            AMOUNT = (total * 100).ToString();
            RETURN_URL = $"{NavigationManager.BaseUri}paymentresult";
            REFERENCE = Invoice.TransactionNumber;
            EMAIL = state.User.Identity.Name;

            for (int i = 1; i <= 29; i++)
            {
                if (i != 29)
                    PaymentOptions.Add((200 + i).ToString(), i.ToString());
                else
                    PaymentOptions.Add((200 + i).ToString(), "Last day of Month");
            }
        }

        private string CalculateChecksum()
        {
            return VezaVIUtils.CreateMD5(VERSION + "|" + PAYGATE_ID + "|" + REFERENCE + "|" + AMOUNT + "|" + CURRENCY + "|" +
                RETURN_URL + "|" + TRANSACTION_DATE + "|" + EMAIL + "|" + SUBS_START_DATE + "|" + SUBS_END_DATE + "|" +
                SUBS_FREQUENCY + "|" + PROCESS_NOW + "|" + PROCESS_NOW_AMOUNT + "|" + KEY);
        }



    

#line default
#line hidden
#nullable disable

        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 5 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\ConfirmSubscription.razor"
        AuthenticationStateProvider

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 5 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\ConfirmSubscription.razor"
                                    AuthenticationStateProvider

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 4 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\ConfirmSubscription.razor"
        ISubscriptionService

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 4 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\ConfirmSubscription.razor"
                             SubscriptionService

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 3 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\ConfirmSubscription.razor"
        ILocalStorageService

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 3 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\ConfirmSubscription.razor"
                             LocalStorage

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 2 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\ConfirmSubscription.razor"
        NavigationManager

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 2 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Pages\Firm\ConfirmSubscription.razor"
                          NavigationManager

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
    }
}
#pragma warning restore 1591