using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Shared
{
    public class ElementDragEventArgs : MouseEventArgs
    {
        public ElementDataTransfer DataTransfer { get; set; }
    }
}
