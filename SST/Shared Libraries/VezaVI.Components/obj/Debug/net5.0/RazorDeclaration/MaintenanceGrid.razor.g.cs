// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace 
#nullable restore
#line 4 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\MaintenanceGrid.razor"
           VezaVI.Light.Components

#line default
#line hidden
#nullable disable
{
    #line default
    using global::System.Collections.Generic;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using System.Net.Http

#nullable disable
    ;
#nullable restore
#line 2 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms

#nullable disable
    ;
#nullable restore
#line 3 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing

#nullable disable
    ;
#nullable restore
#line 4 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using Microsoft.AspNetCore.Components.Web

#nullable disable
    ;
#nullable restore
#line 5 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using Microsoft.JSInterop

#nullable disable
    ;
#nullable restore
#line 6 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using Microsoft.AspNetCore.Authorization

#nullable disable
    ;
#nullable restore
#line 7 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using System.Text.Json

#nullable disable
    ;
#nullable restore
#line 8 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using System.Net.Http.Headers

#nullable disable
    ;
#nullable restore
#line 9 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using VezaVI.Light.Shared

#nullable disable
    ;
#nullable restore
#line 10 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using Blazored.Modal

#nullable disable
    ;
#nullable restore
#line 11 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using Blazored.Modal.Services

#nullable disable
    ;
#nullable restore
#line 12 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using System.Linq

#nullable disable
    ;
#nullable restore
#line 13 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using Blazored.LocalStorage

#nullable disable
    ;
#nullable restore
#line 14 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using System.Text

#nullable disable
    ;
#nullable restore
#line 15 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using System.Net.Http.Json

#nullable disable
    ;
#nullable restore
#line 16 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization

#nullable disable
    ;
#nullable restore
#line 17 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using SixLabors.ImageSharp.Processing

#nullable disable
    ;
#nullable restore
#line 18 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using SixLabors.ImageSharp.Formats

#nullable disable
    ;
#nullable restore
#line 19 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using System

#nullable disable
    ;
#nullable restore
#line 20 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\_Imports.razor"
using SixLabors.ImageSharp

#line default
#line hidden
#nullable disable
    ;
    #nullable restore
    public partial class MaintenanceGrid<
#nullable restore
#line 1 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\MaintenanceGrid.razor"
           TItem

#line default
#line hidden
#nullable disable
    > : MaintenanceGridBase
    #nullable disable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 271 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\MaintenanceGrid.razor"
 
    PaginatedList<TItem> page;
    private string SearchText { get; set; }
    private string CurrentSearchText { get; set; }

    private List<MaintenanceGridColumn> columns = new List<MaintenanceGridColumn>();
    public override void AddColumn(MaintenanceGridColumn column)
    {
        if (!columns.Contains(column))
        {
            columns.Add(column);
            StateHasChanged();
        }
    }

    public override void RemoveColumn(MaintenanceGridColumn column)
    {
        columns.Remove(column);
        StateHasChanged();
    }

    [Parameter]
    public RenderFragment<TItem> AdditionalIcons { get; set; }

    [Parameter]
    public string EditUrl { get; set; } = string.Empty;
    [Parameter]
    public string AdditionalInfo { get; set; } = string.Empty;
    [Parameter]
    public RenderFragment Columns { get; set; }
    [Parameter]
    public string Description { get; set; }
    [Parameter]
    public string Caption { get; set; } = string.Empty;
    [Parameter]
    public string DeleteButtonCaption { get; set; } = "Delete";
    [Parameter]
    public string EditButtonCaption { get; set; } = "Edit";
    [Parameter]
    public RenderFragment EditButtonIcon { get; set; }
    [Parameter]
    public RenderFragment DeleteButtonIcon { get; set; }
    [Parameter]
    public int DefaultPageSize { get; set; } = 20;
    [Parameter]
    public string ButtonCSS { get; set; } = "btn btn-primary";

    [Parameter]
    public RenderFragment<TItem> ModalContent { get; set; }

    private IList<VezaVIGridFilter> _gridFilter/* = new List<VezaVIGridFilter>()*/;
    [Parameter]
    public IList<VezaVIGridFilter> GridFilter {
        get
        {
            return _gridFilter;
        }
        set
        {
            if (_gridFilter == value)
                return;
            _gridFilter = value;
            new Task(async () =>
            {
                await Refresh();
            }).Start();
        }
    }

    public delegate Task RefreshGridDataSource();
    public event RefreshGridDataSource OnRefresh;

    [Parameter]
    public EventCallback<VezaModalSubmitEventArgs<TItem>> OnModalSubmit { get; set; }
    [Parameter]
    public EventCallback<VezaModalSubmitEventArgs<TItem>> OnAfterModalSubmit { get; set; }
    [Parameter]
    public EventCallback<TItem> OnBeforeModalDisplay { get; set; }
    [Parameter]
    public EventCallback<VezaUrlEventArgs> OnBeforeUrlNavigate { get; set; }
    [Parameter]
    public string DeletePrompt { get; set; } = "";
    private string GetDeletePrompt()
    {
        if (!string.IsNullOrEmpty(DeletePrompt))
            return DeletePrompt;
        return $"Are you sure you wish to {DeleteButtonCaption} this record?";
    }
    [Parameter]
    public bool ShowEditButton { get; set; } = true;
    [Parameter]
    public bool ShowDeleteButton { get; set; } = true;
    [Parameter]
    public bool ShowAddButton { get; set; } = true;
    [Parameter]
    public bool ShowSearchBar { get; set; } = true;
    [Parameter]
    public bool ShowImportButton { get; set; } = false;

    public EventCallback<VezaModalSubmitEventArgs<TItem>> AfterModalSubmit { get; set; }
    public EventCallback<TItem> BeforeModalDisplay { get; set; }
    public EventCallback<bool> AfterImport { get; set; }

    private async void PrepareForEdit(TItem item)
    {
        if (EditUrl != string.Empty)
        {
            string url = string.Empty;
            if (item != null)
                url = $"{EditUrl}/{item.GetID().ToString()}"; // "customer/{0}"
            else
                url = EditUrl;
            /*Before Redirect*/
            VezaUrlEventArgs args = new VezaUrlEventArgs(url);
            if (OnBeforeUrlNavigate.HasDelegate)
                await OnBeforeUrlNavigate.InvokeAsync(args);
            /*Navigate*/
            if (!args.Cancel)
                NavigationManager.NavigateTo(args.Url);
        }
        else
        {
            var parameters = new ModalParameters();
            if (item != null)
                parameters.Add("ID", item.GetID());
            else
            {
                parameters.Add("ID", null);
            }
            parameters.Add("ModalContent", ModalContent);
            parameters.Add("OnModalSubmit", OnModalSubmit);
            parameters.Add("AfterModalSubmit", AfterModalSubmit);
            parameters.Add("BeforeModalDisplay", BeforeModalDisplay);

            ModalService.Show(typeof(MaintenanceGridModal<TItem>), (item == null ? $"New {Description}" : $"Edit {Description}"), parameters);
        }
    }

    private async Task PrepareForDelete(TItem item)
    {
        if (await JSRuntime.Confirm(GetDeletePrompt()))
        {
            var result = await VezaDataService.DeleteAsync(item.GetID());
            if (!result.Successful) {
                ModalParameters param = new ModalParameters();
                param.Add("Message", result.Errors.FirstOrDefault());
                ModalService.Show(typeof(MsgBox), "Delete Failed", param);
            }
            await Refresh();
        }
    }

    private async Task RefreshScreen()
    {
        //await InvokeAsync(() => StateHasChanged());
        StateHasChanged();
    }

    protected async override Task OnInitializedAsync()
    {
        OnRefresh += RefreshScreen;
        AfterModalSubmit = EventCallback.Factory.Create<VezaModalSubmitEventArgs<TItem>>(this, RefreshGrid);
        BeforeModalDisplay = EventCallback.Factory.Create<TItem>(this, NewModalShowing);
        AfterImport = EventCallback.Factory.Create<bool>(this, AfterImportMethod);
    }

    public async Task NewModalShowing(TItem item)
    {
        if (OnBeforeModalDisplay.HasDelegate)
        {
            await OnBeforeModalDisplay.InvokeAsync(item);
        }
    }

    public async Task RefreshGrid(VezaModalSubmitEventArgs<TItem> args)
    {
        await Refresh();
        if (OnAfterModalSubmit.HasDelegate)
        {
            await OnAfterModalSubmit.InvokeAsync(args);
        }
        OnRefresh?.Invoke();
    }

    public async Task Refresh()
    {
        page = await VezaDataService.GetListAsync(GridFilter, PageNumber, DefaultPageSize, CurrentSortField, CurrentSortOrder, CurrentSearchText);
        OnRefresh?.Invoke();
    }

    public override async Task SortAsync(string sortField)
    {
        if (sortField.Equals(CurrentSortField))
        {
            CurrentSortOrder = CurrentSortOrder.Equals("Asc") ? "Desc" : "Asc";
        }
        else
        {
            CurrentSortField = sortField;
            CurrentSortOrder = "Asc";
        }
        await Refresh();
    }

    public override string SortIndicator(string sortField)
    {
        if (sortField.Equals(CurrentSortField))
        {
            return CurrentSortOrder.Equals("Asc") ? "oi oi-sort-ascending" : "oi oi-sort-descending";
        }
        return "oi oi-elevator";
    }

    public async void PageIndexChanged(int newPageNumber)
    {
        if (newPageNumber < 1 || newPageNumber > page.TotalPages)
        {
            return;
        }
        PageNumber = newPageNumber;
        await Refresh();
    }

    public async void Search()
    {
        PageNumber = 1;
        CurrentSearchText = SearchText;
        await Refresh();
    }

    private async Task Import()
    {
        var parameters = new ModalParameters();
        parameters.Add("AfterImport", EventCallback.Factory.Create<bool>(this, AfterImport));
        parameters.Add("AdditionalInfo", AdditionalInfo);
        ModalService.Show(typeof(MaintenanceGridImportModal<TItem>), $"Import {VezaVIUtils.Plural(Description)}", parameters);
    }

    private async Task AfterImportMethod(bool args)
    {
        await Refresh();
    }


#line default
#line hidden
#nullable disable

        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 7 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\MaintenanceGrid.razor"
        IJSRuntime

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 7 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\MaintenanceGrid.razor"
                   JSRuntime

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 6 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\MaintenanceGrid.razor"
        NavigationManager

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 6 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\MaintenanceGrid.razor"
                          NavigationManager

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 5 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\MaintenanceGrid.razor"
        IModalService

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 5 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\MaintenanceGrid.razor"
                      ModalService

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 2 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\MaintenanceGrid.razor"
        IVezaDataService<TItem>

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 2 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\MaintenanceGrid.razor"
                                VezaDataService

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
    }
}
#pragma warning restore 1591
