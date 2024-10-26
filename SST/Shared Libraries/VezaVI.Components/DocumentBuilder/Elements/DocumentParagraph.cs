using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace VezaVI.Light.Components
{
    [AllowedConfig(ConfigType.Alignment)]
    [AllowedConfig(ConfigType.ChangeTextType)]
    [AllowedConfig(ConfigType.HeaderSize)]
    [AllowedConfig(ConfigType.Indent, 0, 5)]
    [AllowedConfig(ConfigType.Bold)]
    [AllowedConfig(ConfigType.Italic)]
    [AllowedConfig(ConfigType.Underline)]
    [AllowedConfig(ConfigType.AutoNumber)]
    [AllowedConfig(ConfigType.RestartNumbering)]
    public class DocumentParagraph : IDragableElement, INotifyPropertyChanged
    {
        [Inject]
        public IJSRuntime JS { get; set; }
        public Guid? ElementID { get; set; }
        public string Caption => "Document Paragraph";
        public DocumentBuilderElementListType State { get; set; }
        public string Number { get; set; }

        public IDragableElement CreateNew(DocumentBuilderElementListType state)
        {
            return new DocumentParagraph()
            {
                State = state
            };
        }

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

        public Type RenderType => typeof(DocumentParagraphRenderer);

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Notify Changes
    }

    public class DocumentParagraphRenderer : ComponentBase, IDragableComponent
    {
        [Inject]
        public IJSRuntime JS { get; set; }
        [Parameter]
        public IDragableElement Element { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            int seq = 0;
            if (Element.State == DocumentBuilderElementListType.Toolbar)
            {
                builder.OpenElement(++seq, "span");
                builder.AddAttribute(++seq, "class", "oi oi-justify-left");
                builder.CloseElement();
                builder.AddContent(++seq, Element.Caption);
            }
            else
            {
                builder.OpenElement(++seq, "span");
                builder.AddAttribute(++seq, "class", "oi oi-justify-left vi-editor-icon");
                builder.CloseElement();

                builder.OpenElement(++seq, "div"); /*Padding Goes Here*/
                string paddingStr = "";
                foreach (var config in Element.GetConfigValues().Where(x => x.Key == ConfigType.Indent))
                {
                    paddingStr += $"{config.Value} ";
                }
                builder.AddAttribute(++seq, "class", paddingStr);

                if (!string.IsNullOrWhiteSpace(Element.Number)) /*Margin goes here*/
                {
                    builder.OpenElement(++seq, "span");
                    builder.AddAttribute(++seq, "class", "vi-auto-number");
                    builder.AddContent(++seq, Element.Number);
                    builder.CloseElement();
                }

                builder.OpenElement(++seq, "span");
                builder.AddAttribute(++seq, "class", "form-editor");

                builder.OpenElement(++seq, "div");
                builder.AddAttribute(++seq, "contenteditable", "true");


                string classStr = "vi-text-area-div ";
                foreach (var config in Element.GetConfigValues().Where(x => x.Key != ConfigType.Indent))
                {
                    classStr += $"{config.Value} ";
                }
                builder.AddAttribute(++seq, "class", classStr);
                builder.AddAttribute(++seq, "onblur", EventCallback.Factory.Create(this, OnChange));
                 
                builder.AddElementReferenceCapture(++seq, ElementReferenceCaptured);

                //builder.AddContent(++seq, Element.Value);

                builder.CloseElement(); //textarea div
                builder.CloseElement();
                builder.CloseElement();

                builder.OpenElement(++seq, "button");
                builder.AddAttribute(++seq, "onclick", EventCallback.Factory.Create(this, OnChange));
                builder.AddContent(++seq, "Get Content");
                builder.CloseElement();

                builder.OpenElement(++seq, "div");
                builder.AddContent(++seq, content);
                builder.CloseElement();

            }
        }

        private string content = string.Empty;
        ElementReference _elementReference;
        private void ElementReferenceCaptured(ElementReference elementReference)
        {
            _elementReference = elementReference;
        }

        private async void OnChange()
        {
            string tmp = await JS.InvokeAsync<string>("JsLib.getInnerHtml", _elementReference);
            Element.Value = content = tmp;
            StateHasChanged();
        }

    }
}
