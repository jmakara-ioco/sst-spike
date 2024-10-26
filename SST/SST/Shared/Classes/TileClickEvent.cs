using System;
using System.Collections.Generic;
using System.Text;

namespace SST.Shared
{
    public class TileClickEvent : EventArgs
    {
        public TileClickEvent(Guid id)
        {
            TileID = id;
        }

        public Guid TileID { get; set; }
    }
}
