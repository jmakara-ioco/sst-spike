using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SST.Client;
using Blazored.Modal;
using VezaVI.Light.Components;
using SST.Shared;
using SST.Client.Services;
using Microsoft.AspNetCore.Components;

namespace SST.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IMailService, MailService>();
            builder.Services.AddScoped<IFirmService, FirmService>();
            builder.Services.AddScoped<IStoreService, StoreService>();
            builder.Services.AddScoped<IAutomaticMeetingService, AutomaticMeetingService>();
            builder.Services.AddScoped<IQuestionProcessService, QuestionProcessService>();
            builder.Services.AddScoped<IPaymentGateService, PaymentGateService>();
            builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
            builder.Services.AddScoped<IContractHistoryService, ContractHistoryService>();
            builder.Services.AddScoped<IQuestionSimulationDisplayService, QuestionSimulationDisplayService>();
            builder.Services.AddScoped<IEditorEntityClauseService, EditorEntityClauseService>();
            builder.Services.AddScoped<ITenantHelperService, TenantHelperService>();
            builder.Services.AddScoped<ICustomRegistrationService, CustomerRegistrationService>();

            builder.Services.AddScoped<IVezaDataService<ApplicationUser>, UserService>();
            builder.Services.AddScoped<IVezaDataService<Country>, CountryService>();
            builder.Services.AddScoped<IVezaDataService<IntroStep>, IntroStepService>();
            builder.Services.AddScoped<IVezaDataService<Customer>, CustomerService>();
            builder.Services.AddScoped<IVezaDataService<Field>, CustomerFieldService>();
            builder.Services.AddScoped<IVezaDataService<ContractTransaction>, ContractTransactionService>();
            builder.Services.AddScoped<IVezaDataService<ContractTransactionDataField>, ContractTransactionDataFieldService>();
            builder.Services.AddScoped<IVezaDataService<ContractQuestion>, ContractQuestionService>();
            builder.Services.AddScoped<IVezaDataService<ContractQuestionAnswer>, ContractQuestionAnswerService>();
            builder.Services.AddScoped<IVezaDataService<ContractQuestionAnswerDataField>, ContractQuestionAnswerDataFieldService>();
            builder.Services.AddScoped<IVezaDataService<ContractQuestionDataField>, ContractQuestionDataFieldService>();
            builder.Services.AddScoped<IVezaDataService<CustomerDataField>, CustomerDataFieldService>();
            builder.Services.AddScoped<IVezaDataService<ContractClause>, ContractClauseService>();
            builder.Services.AddScoped<IVezaDataService<ContractTransactionTemplate>, ContractTransactionTemplateService>();
            builder.Services.AddScoped<IVezaDataService<ContractTemplateElement>, ContractTemplateElementService>();
            builder.Services.AddScoped<IVezaDataService<ContractHistory>, ContractHistoryStandardService>();
            builder.Services.AddScoped<IVezaDataService<FirmStyling>, FirmStylingService>();
            builder.Services.AddScoped<IVezaDataService<ContractQuestionIgnoredContractClause>, ContractQuestionIgnoredContractClauseService>();
            builder.Services.AddScoped<IVezaDataService<ContractTransactionEntity>, ContractTransactionEntityService>();
            builder.Services.AddScoped<IVezaDataService<ContractTransactionEntityDataField>, ContractTransactionEntityDataFieldService>();
            builder.Services.AddScoped<IVezaDataService<ContractTransactionEntityClause>, ContractTransactionEntityClauseService>();
            builder.Services.AddScoped<IVezaDataService<ContractQuestionTemplate>, ContractQuestionTemplateService>();
            builder.Services.AddScoped<IVezaDataService<ContractQuestionAnswerIgnoredClause>, ContractQuestionAnswerIgnoredClauseService>();
            builder.Services.AddScoped<IVezaDataService<InvoiceHeader>, InvoiceHeaderService>();
            
            builder.Services.AddScoped<ITenantHelperService, TenantHelperService>(s =>
            {
                var styling = s.GetRequiredService<IVezaDataService<FirmStyling>>();
                var nav = s.GetRequiredService<NavigationManager>();
                var httpClient = s.GetRequiredService<HttpClient>();
                var authState = s.GetRequiredService<AuthenticationStateProvider>();
                return new TenantHelperService(nav, authState, styling, httpClient);
            }
            );

            builder.Services.AddBlazoredModal();
            builder.Services.AddVezaVILite();
            await builder.Build().RunAsync();
        }
    }
}
