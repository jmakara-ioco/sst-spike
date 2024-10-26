using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace VezaVI.Light.Components
{
    public partial class MaintenanceGridModal<TItem> where TItem : class, IVezaVIRecordBase, new()
    {
        public MaintenanceGridModal()
        {
        }
        //[Parameter] public TItem Type { get; set; }
    }
}
