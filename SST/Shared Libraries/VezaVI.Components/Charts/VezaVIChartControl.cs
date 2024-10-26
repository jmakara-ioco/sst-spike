using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VezaVI.Light.Shared;

namespace VezaVI.Light.Components
{
    public class VezaVIChartControl : OwningComponentBase
    {
        public VezaSerie Serie { get; private set; }

        protected async override Task OnInitializedAsync()
        {
            Serie = await LoadChartData();
            StateHasChanged();
        }

        public virtual async Task<VezaSerie> LoadChartData()
        {
            return new VezaSerie();
        }

        public virtual string[] GetColours()
        {
            return new string[] { "#f2c40f", "#fdbb30", "#0f0f0f", "#242020", "#524e4e", "#f2cc0f" };
        }
    }
}
