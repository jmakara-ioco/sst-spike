using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using VezaVI.Light.Shared;

namespace VezaVI.Light.Components
{
    [AllowedConfig(ConfigType.UserField)]
    [AllowedConfig(ConfigType.Alignment)]
    [AllowedConfig(ConfigType.Bold)]
    [AllowedConfig(ConfigType.Italic)]
    [AllowedConfig(ConfigType.Underline)]
    [AllowedConfig(ConfigType.ChangeTextType)]
    [AllowedConfig(ConfigType.HeaderSize)]
    [AllowedConfig(ConfigType.Indent, 0, 5)]
    [AllowedConfig(ConfigType.AutoNumber)]
    [AllowedConfig(ConfigType.RestartNumbering)]
    public class DocumentUserField : IDragableElement, INotifyPropertyChanged
    {
        public Guid? ElementID { get; set; }
        public string Caption => "User Defined Field";
        public DocumentBuilderElementListType State { get; set; }
        public string Number { get; set; }

        #region Notify Changes

        private int _indent = 0;
        public int Indent
        {
            get
            {
                return _indent;
            }
            set
            {
                if (_indent == value)
                    return;
                _indent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Indent"));
            }
        }

        private int _sort = 0;
        public int Sort
        {
            get
            {
                return _sort;
            }
            set
            {
                if (_sort == value)
                    return;
                _sort = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sort"));
            }
        }

        private string _value = string.Empty;
        public string Value
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }

        private string _configOptions = string.Empty;
        public string ConfigOptions
        {
            get
            {
                return _configOptions;
            }
            set
            {
                if (_configOptions == value)
                    return;
                _configOptions = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ConfigOptions"));
            }
        }

        public Type RenderType => typeof(DocumentUserFieldRenderer);

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Notify Changes

        public IDragableElement CreateNew(DocumentBuilderElementListType state)
        {
            return new DocumentUserField()
            {
                State = state
            };
        }
    }

    public class DocumentUserFieldRenderer : ComponentBase, IDragableComponent
    {
        [Parameter]
        public IDragableElement Element { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            int seq = 0;
            if (Element.State == DocumentBuilderElementListType.Toolbar)
            {
                builder.OpenElement(seq++, "span");
                builder.AddAttribute(seq++, "class", "oi oi-tags");
                builder.CloseElement();
                builder.AddContent(++seq, Element.Caption);
            }
            else
            {
                builder.OpenElement(seq++, "span");
                builder.AddAttribute(seq++, "class", "oi oi-tags vi-editor-icon");
                builder.CloseElement();

                builder.OpenElement(seq++, "span");
                builder.AddAttribute(seq++, "class", "form-editor");

                builder.OpenElement(seq++, "input");

                string classStr = string.Empty;
                foreach (var config in Element.GetConfigValues())
                {
                    classStr += $"{config.Value} ";
                }
                builder.AddAttribute(++seq, "class", classStr);
                builder.AddAttribute(++seq, "value", Element.Value);
                builder.AddAttribute(++seq, "onchange", EventCallback.Factory.CreateBinder(this, __value => Element.Value = __value, Element.Value));
                builder.CloseElement();

                builder.CloseElement();
            }
        }
    }
}
