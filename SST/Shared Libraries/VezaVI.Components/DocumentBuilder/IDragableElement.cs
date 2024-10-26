using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using VezaVI.Light.Shared;

namespace VezaVI.Light.Components
{
    public interface IDragableElement
    {
        DocumentBuilderElementListType State { get; set; }
        string Number { get; set; }
        Guid? ElementID { get; set; }
        string Caption { get; }
        int Indent { get; set; }
        int Sort { get; set; }
        string Value { get; set; }
        string ConfigOptions { get; set; }

        Type RenderType { get; }

        IDragableElement CreateNew(DocumentBuilderElementListType state);
    }

    public interface IDragableComponent
    {
        IDragableElement Element { get; set; }
    }
}
