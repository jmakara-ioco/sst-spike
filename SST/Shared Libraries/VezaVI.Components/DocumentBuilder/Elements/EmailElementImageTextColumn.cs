using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VezaVI.Light.Shared;

namespace VezaVI.Light.Components
{
    [AllowedConfig(ConfigType.Alignment)]
    [AllowedConfig(ConfigType.Bold)]
    [AllowedConfig(ConfigType.Italic)]
    [AllowedConfig(ConfigType.Underline)]
    [AllowedConfig(ConfigType.ChangeTextType)]
    [AllowedConfig(ConfigType.HeaderSize)]
    public class EmailElementImageTextColumn : IDragableElement, INotifyPropertyChanged
    {
        public Guid? ElementID { get; set; }
        public string Caption => "Email Element (Image | Text)";
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Indent)));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Sort)));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConfigOptions)));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Notify Changes

        public IDragableElement CreateNew(DocumentBuilderElementListType state)
        {
            return new EmailElementImageTextColumn()
            {
                State = state
            };
        }
        
        public Type RenderType => typeof(EmailElementImageTextColumnRenderer);
    }

    public class EmailElementImageTextColumnRenderer : ComponentBase, IDragableComponent
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            int seq = 0;
            if (Element.State == DocumentBuilderElementListType.Toolbar)
            {
                builder.OpenElement(seq++, "span");
                builder.AddAttribute(seq++, "class", "oi oi-browser");
                builder.CloseElement();
                builder.AddContent(++seq, Element.Caption);
            }
            else
            {
                builder.OpenElement(seq++, "span");
                builder.AddAttribute(seq++, "class", "form-editor");

                builder.OpenElement(++seq, "div");
                builder.AddAttribute(++seq, "class", "drag-drop-zone");
                builder.AddAttribute(++seq, "style", "width: 50%; float: left;");

                builder.OpenComponent(++seq, typeof(InputFile));
                builder.AddAttribute(++seq, "OnChange", EventCallback.Factory.Create<InputFileChangeEventArgs>(this, UploadFooter));
                builder.AddAttribute(++seq, "MaxBufferSize", MaxFileSize);
                builder.CloseComponent();

                if (string.IsNullOrEmpty(Image))
                {
                    builder.OpenElement(seq++, "label");
                    builder.AddContent(++seq, footerStatus);
                    builder.CloseElement();
                }
                else
                {
                    builder.OpenElement(seq++, "img");
                    builder.AddAttribute(++seq, "src", Image);
                    builder.CloseElement();
                }

                builder.CloseElement();

                builder.OpenElement(seq++, "textarea");
                builder.AddAttribute(++seq, "style", "width: 50%; height: 100%; float: right;");
                string classStr = string.Empty;
                foreach (var config in Element.GetConfigValues())
                {
                    classStr += $"{config.Value} ";
                }
                builder.AddAttribute(++seq, "class", classStr);
                builder.AddAttribute(++seq, "value", Text);
                builder.AddAttribute(++seq, "onchange", EventCallback.Factory.CreateBinder(this, __value => Text = __value, Text));
                builder.CloseElement();

                builder.CloseElement();
            }
        }

        const string DefaultStatus = "Drop a file here to view it, or click to choose a file";
        const int MaxFileSize = 1 * 1024 * 1024; // 1MB
        string footerStatus = DefaultStatus;

        async Task UploadFooter(InputFileChangeEventArgs e)
        {
            var file = e.File;
            if (file == null)
            {
                return;
            }
            else if (file.Size > MaxFileSize)
            {
                footerStatus = $"That's too big. Max size: {MaxFileSize} bytes.";
            }
            else
            {
                footerStatus = "Loading...";

                var format = "image/png";
                var resizedImageFile = await file.RequestImageFileAsync(format, 256, 256);
                var buffer = new byte[resizedImageFile.Size];
                await resizedImageFile.OpenReadStream().ReadAsync(buffer);
                var imageDataUrl = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
                Image = imageDataUrl;

                footerStatus = DefaultStatus;
            }
        }

        private string Image
        {
            get
            {
                if (Element.Value != null && Element.Value.Contains("|||"))
                    return Element.Value.Split("|||")[1];
                return "";
            }
            set
            {
                Element.Value = Text + "|||" + value;
            }
        }

        private string Text
        {
            get
            {
                if (Element.Value != null && Element.Value.Contains("|||"))
                    return Element.Value.Split("|||")[0];
                return "";
            }
            set
            {
                Element.Value = value + "|||" + Image;
            }
        }

        [Parameter]
        public IDragableElement Element { get; set; }
    }
}
