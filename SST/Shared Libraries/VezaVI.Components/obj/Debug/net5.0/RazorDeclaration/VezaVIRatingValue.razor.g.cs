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
    public partial class VezaVIRatingValue : global::Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    #nullable disable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 5 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\VezaVIRatingValue.razor"
       
    [CascadingParameter]
    public VezaVIRatingControl Control { get; set; }
    [Parameter]
    public int Value { get; set; }
    [Parameter]
    public string TextValue { get; set; }

    private string Current
    {
        get
        {
            return (Control.Value == Value) ? "br-current" : "";
        }
    }

    private bool IsSelected
    {
        get
        {
            if (Control.HoverValue != null)
            {
                return (Control.HoverValue >= Value);
            }
            else
            {
                if (Control.Value != null)
                {
                    return (Control.Value >= Value);
                }
                else
                    return false;
            }
        }
    }

    private string Selected
    {
        get
        {
            return IsSelected ? "br-selected" : "";
        }
    }

    private string BackgroundColorCSS
    {
        get
        {
            return Control.DisplayType == RatingControlDisplayType.Blocks ? "background-color: white;" : (IsSelected ? $"background-color: {Control.ColorHex};" : $"background-color: {Control.ColorHex}85;");
        }
    }

    private string DisplayText
    {
        get
        {
            return (Control.DisplayType == RatingControlDisplayType.Pill) ? TextValue : ((Control.DisplayType == RatingControlDisplayType.TextRating || Control.DisplayType == RatingControlDisplayType.HorizontalBar)  ? "" : Value.ToString());
        }
    }

    private string BorderCss
    {
        get
        {
            return Control.DisplayType == RatingControlDisplayType.Blocks ?  (IsSelected ? $"border-color: {Control.ColorHex}; color: {Control.ColorHex};" : $"border-color: {Control.ColorHex}85; color: {Control.ColorHex}85;") : "";
        }
    }

    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }

    protected async override Task OnInitializedAsync()
    {
        Control.AddValue(this);
    }

    public void Dispose()
    {
        Control.RemoveValue(this);
    }

#line default
#line hidden
#nullable disable

    }
}
#pragma warning restore 1591
