using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Shared
{
    public partial class VezaModalSubmitEventArgs<TItem> : EventArgs where TItem : class, IVezaVIRecordBase, new()
    {
        public VezaModalSubmitEventArgs(TItem item)
        {
            Item = item;
        }
        public TItem Item { get; set; }
        public bool AllowClose { get; set; } = true;
        public IList<string> Errors { get; set; } = new List<string>();
    }
}
