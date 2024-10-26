using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace VezaVI.Light.Components
{
    public enum DisplayAs
    {
        Grid,
        PanelRows,
        Tiles
    }
    public partial class MaintenanceGrid<TItem> where TItem : class, IVezaVIRecordBase, new()
    {
        [Parameter] public TItem Type { get; set; }
    }
}
