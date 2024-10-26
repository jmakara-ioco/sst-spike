using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace VezaVI.Light.Components
{
    public partial class MaintenanceGridImportModal<TItem> where TItem : class, IVezaVIRecordBase, new()
    {
        public MaintenanceGridImportModal()
        {
        }
        //[Parameter] public TItem Type { get; set; }
    }
}
