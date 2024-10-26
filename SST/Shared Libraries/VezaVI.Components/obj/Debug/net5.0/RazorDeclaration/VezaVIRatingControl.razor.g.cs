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
    public partial class VezaVIRatingControl : global::Microsoft.AspNetCore.Components.ComponentBase
    #nullable disable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 17 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\Shared Libraries\VezaVI.Components\VezaVIRatingControl.razor"
       

    private string WidgetCSS
    {
        get
        {
            return (DisplayType == RatingControlDisplayType.Blocks ? "br-theme-bars-square" :
                (DisplayType == RatingControlDisplayType.HorizontalBar ? "br-theme-bars-1to10" :
                (DisplayType == RatingControlDisplayType.Pill ? "br-theme-bars-pill" :
                "br-theme-bars-movie")));
        }
    }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string ColorHex { get; set; } = "#50E3C2";

    [Parameter]
    public RatingControlDisplayType DisplayType { get; set; } = RatingControlDisplayType.Blocks;

    [Parameter]
    public EventCallback<int?> ValueChanged { get; set; }

    private int? _value = null;
    [Parameter]
    public int? Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (_value == value)
                return;
            _value = value;
            ValueChanged.InvokeAsync(value);
        }
    }

    [Parameter]
    public string Id { get; set; }

    private List<VezaVIRatingValue> Values = new List<VezaVIRatingValue>();

    public void AddValue(VezaVIRatingValue value)
    {
        Values.Add(value);
        StateHasChanged();
    }

    public void RemoveValue(VezaVIRatingValue value)
    {
        Values.Remove(value);
        StateHasChanged();
    }

    internal int? HoverValue { get; set; } = null;

    public void SetHover(int? value)
    {
        HoverValue = value;
        StateHasChanged();
    }

    public void SetValue(int? value)
    {
        Value = value;
        StateHasChanged();
    }

    private string GetDisplayText
    {
        get
        {
            if (HoverValue != null)
            {
                foreach (var value in Values)
                {

                    if (value.Value == HoverValue)
                        return value.TextValue;
                }
            }
            foreach (var value in Values)
            {
                if (value.Value == Value)
                    return value.TextValue;
            }
            return "";
        }
    }


#line default
#line hidden
#nullable disable

    }
}
#pragma warning restore 1591
