// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace VezaVI.Light.Components
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
    public partial class VezaVITab : global::Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    #nullable disable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 19 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\VezaVITab.razor"
       
    [Parameter]
    public RenderFragment ChildContent { get; set; }
    [CascadingParameter]
    public VezaVITabControl TabControl { get; set; }
    [Parameter]
    public string AdditionalActiveCSS { get; set; }
    [Parameter]
    public string AdditionalHeaderCSS { get; set; }
    [Parameter]
    public string AdditionalCSS { get; set; }
    [Parameter]
    public string Caption { get; set; }
    [Parameter]
    public bool LoadOnFocus { get; set; } = true;

    protected async override Task OnInitializedAsync()
    {
        TabControl.AddTab(this);
    }

    public void Dispose()
    {
        TabControl.RemoveTab(this);
    }

    private string TabCSS
    {
        get
        {
            return (TabControl.IsActiveTab(this)) ? AdditionalActiveCSS : AdditionalCSS;
        }
    }

    private string TabStyle
    {
        get
        {
            return (TabControl.IsActiveTab(this)) ? $"display: block;" : "display: none;";
        }
    }

#line default
#line hidden
#nullable disable

    }
}
#pragma warning restore 1591
