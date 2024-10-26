using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Components
{
    public enum ElementAction
    {
        Add,
        Update,
        Delete
    }
    public partial class VezaDragableElementSaveEventArgs : EventArgs
    {
        public VezaDragableElementSaveEventArgs(IDragableElement element, ElementAction action)
        {
            Element = element;
            Action = action;
        }

        public IDragableElement Element { get; set; }
        public bool Succeeded { get; set; } = true;
        public ElementAction Action { get; set; } = ElementAction.Add;
    }
}
