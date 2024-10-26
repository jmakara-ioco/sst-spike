// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SST.Client.Shared
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
    public partial class QuestionIgnoredClausesNode : global::Microsoft.AspNetCore.Components.ComponentBase
    #nullable disable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 25 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionIgnoredClausesNode.razor"
       

    private Guid _questionID = Guid.Empty;
    [Parameter]
    public Guid QuestionID
    {
        get
        {
            return _questionID;
        }
        set
        {
            _questionID = value;
            OnRefresh?.Invoke();
        }
    }

    private delegate Task Refresh();
    private event Refresh OnRefresh;

    [Parameter]
    public Guid ContractTransactionID { get; set; }
    [Parameter]
    public string NullText { get; set; }
    private bool _isOpen = false;
    public string SelectedText { get; set; } = string.Empty;

    public List<ContractQuestionIgnoredContractClause> selectedItems { get; set; } = new List<ContractQuestionIgnoredContractClause>();
    public List<VezaMultiItem> DisplayItems { get; set; } = new List<VezaMultiItem>();

    [CascadingParameter]
    public QuestionNodeTreeBuilder TreeBuilder { get; set; }

    protected async override Task OnInitializedAsync()
    {
        OnRefresh += RefreshQuestion;
        await RefreshQuestion();
    }

    private async Task RefreshQuestion()
    {
        var questionDataFields = await ContractQuestionIgnoredContractClauseService.GetAllAsync("ID", new List<VezaVIGridFilter>()
        {
            new VezaVIGridFilter() { Field = "QuestionID", Value = QuestionID.ToString(), Equals = true }
        });
        selectedItems = questionDataFields.Items;
        await InvokeAsync(() => StateHasChanged());
    }

    public List<VezaMultiItem> SelectedItems
    {
        get
        {
            return selectedItems.Select(x => new VezaMultiItem() { Key = x.ID, DisplayText = TreeBuilder.GetAllContractClauses().FirstOrDefault(y => y.ID == x.ContractClauseID)?.Code }).ToList();
        }
    }

    public async void TrySelect(VezaMultiItem item)
    {
        ContractQuestionIgnoredContractClause clause = new ContractQuestionIgnoredContractClause()
        {
            QuestionID = QuestionID,
            ContractClauseID = item.Key
        };
        /*Save*/
        var result = await ContractQuestionIgnoredContractClauseService.AddAsync(clause);
        if (result.Successful)
        {
            selectedItems.Add(clause);
            SelectedText = string.Empty;
            StateHasChanged();
        }
    }

    public async void TryRemove(VezaMultiItem item)
    {
        /*Delete*/
        var result = await ContractQuestionIgnoredContractClauseService.DeleteAsync(item.Key);
        if (result.Successful)
        {
            var removedItem = selectedItems.FirstOrDefault(x => x.ID == item.Key);
            selectedItems.Remove(removedItem);
            StateHasChanged();
        }
    }

    private void TryAutoComplete(FocusEventArgs ev)
    {
        _isOpen = true;
        DisplayItems = TreeBuilder.GetAllContractClauses().Select(x => new VezaMultiItem() { Key = x.ID, DisplayText = x.Code }).ToList().Where(x => x.DisplayText.Contains(SelectedText, StringComparison.InvariantCultureIgnoreCase)).ToList();
    }

#line default
#line hidden
#nullable disable

        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 1 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionIgnoredClausesNode.razor"
        IVezaDataService<ContractQuestionIgnoredContractClause>

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 1 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionIgnoredClausesNode.razor"
                                                                ContractQuestionIgnoredContractClauseService

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
    }
}
#pragma warning restore 1591
