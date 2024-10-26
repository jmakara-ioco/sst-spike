using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class FirmStyling : VezaVIGuidRecordBase
    {
        public Guid FirmID { get; set; }

        [JsonIgnore]
        public Firm Firm { get; set; }
        //Allow link to TransactionID
        //Indent Options
        //Header Config
        //Footer Config
        //Pre

        public string ButtonColor { get; set; } = "#abd044";
        public string ButtonFontColor { get; set; } = "#ffffff";
        public string HeadingColor { get; set; } = "#215ba8";
        public string MenuHeadingColor { get; set; } = "#abd044";
        public string MenuFontColor { get; set; } = "#ffffff";
        public string MenuBackgroundColor { get; set; } = "rgb(0 0 0 / 50%)";

        public string Font { get; set; } = "Calibri";

        public string H1Colour { get; set; } = "#000000";
        public double H1Size { get; set; } = 20;

        public string H2Colour { get; set; } = "#000000";
        public double H2Size { get; set; } = 18;

        public string H3Colour { get; set; } = "#000000";
        public double H3Size { get; set; } = 16;

        public string ParColour { get; set; } = "#000000";
        public double ParSize { get; set; } = 14;
        public int ParagraphPadding { get; set; } = 1;

        public int LineSpacing { get; set; } = 0;
        public int IndentSetting { get; set; } = 0;

        public int HeaderLeft { get; set; } = 0;
        public int HeaderCenter { get; set; } = 0;
        public int HeaderRight { get; set; } = 0;
        public int FooterLeft { get; set; } = 0;
        public int FooterCenter { get; set; } = 0;
        public int FooterRight { get; set; } = 0;
        public bool ShowFooterLine { get; set; } = true;
        public bool ShowHeaderLine { get; set; } = true;
        public int HeaderHeight { get; set; } = 10;
        public int FooterHeight { get; set; } = 10;
        

        //1. 1.1 1.1.1
        //1. a. i.
        public string GenerateScripts()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<script type=\"text/JavaScript\">");
            builder.Append("var x = document.getElementsByTagName(\"H1\");");
            builder.Append(Environment.NewLine);
            builder.Append("var index = '<h1>Index</h1>';");
            builder.Append(Environment.NewLine);
            builder.Append("for (i = 0; i < x.length; i++) {");
            builder.Append(Environment.NewLine);
            builder.Append("index += '<h3>' + x[i].innerText + '</h3>';");
            builder.Append(Environment.NewLine);
            builder.Append("}");
            builder.Append(Environment.NewLine);
            builder.Append("document.getElementById(\"index\").innerHTML = index;");
            builder.Append(Environment.NewLine);
            builder.Append("</script>");
            return builder.ToString();
        }

        public string GenerateStyleSheet()
        {
            string margin = $"{LineSpacing}px";
            StringBuilder builder = new StringBuilder();
            builder.Append("<style type=\"text/css\">");
            /*builder.Append(Environment.NewLine);
            builder.Append($"#VezaRichTextBox body {{ font-family: {Font}; }}");*/
            builder.Append(Environment.NewLine);
            builder.Append($"#VezaRichTextBox {{ font-family: {Font}; }}");
            builder.Append(Environment.NewLine);
            builder.Append($"#index h1 {{ font-size: {H1Size}px; color: {H1Colour} !important;  margin-bottom: {margin}; margin-top: {margin}; }}");
            builder.Append(Environment.NewLine);
            builder.Append($"#index h3 {{ font-size: {H3Size}px; color: {H3Colour} !important;  margin-bottom: {margin}; margin-top: {margin}; }}");
            builder.Append(Environment.NewLine);
            builder.Append($"#VezaRichTextBox h1 {{ font-size: {H1Size}px; color: {H1Colour} !important;  margin-bottom: {margin}; margin-top: {margin}; }}");
            builder.Append(Environment.NewLine);
            builder.Append($"#VezaRichTextBox h2 {{ font-size: {H2Size}px; color: {H2Colour} !important;  margin-bottom: {margin}; margin-top: {margin}; }}");
            builder.Append(Environment.NewLine);
            builder.Append($"#VezaRichTextBox h3 {{ font-size: {H3Size}px; color: {H3Colour} !important;  margin-bottom: {margin}; margin-top: {margin}; }}");
            builder.Append(Environment.NewLine);
            builder.Append($"#VezaRichTextBox p {{ font-size: {ParSize}px; color: {ParColour} !important; padding-bottom: {ParagraphPadding} !important;  margin-bottom: {margin}; margin-top: {margin}; }}");
            builder.Append(Environment.NewLine);
            builder.Append($"#VezaRichTextBox ol {{ list-style-type: none; margin-bottom: {margin}; margin-top: {margin}; }}");
            builder.Append(Environment.NewLine);

            for (int i = 1; i <= 10; i++)
            {
                if (i == 1)
                    builder.Append($"#VezaRichTextBox {{ counter-reset: number{i}; list-style-type: none; }}");
                else
                    builder.Append($"#VezaRichTextBox {GenerateOL(i)} {{ counter-reset: number{i}; list-style-type: none; }}");
                builder.Append(Environment.NewLine);
                builder.Append($"#VezaRichTextBox {GenerateOL(i)} li::before {{ content: {GenerateMarker(i, IndentSetting)};  }}"); //marker
                builder.Append(Environment.NewLine);
                builder.Append($"#VezaRichTextBox {GenerateOL(i)} li {{ counter-increment: number{i}; list-style-position: inside; text-indent: -2em; padding-left: {GetPadding(i)};  }}");
                builder.Append(Environment.NewLine);
            }
            builder.Append("</style>");
            return builder.ToString();
        }

        public string GenerateHeader(IHttpContextAccessor httpContext)
        {
            string left = GetHeaderText(HeaderLeft, httpContext, HeaderHeight);
            string center = GetHeaderText(HeaderCenter, httpContext, HeaderHeight);
            string right = GetHeaderText(HeaderRight, httpContext, HeaderHeight);
            return $"{left}{center}{right}";
        }

        public string GenerateFooter(IHttpContextAccessor httpContext)
        {
            string left = GetHeaderText(FooterLeft, httpContext, FooterHeight);
            string center = GetHeaderText(FooterCenter, httpContext, FooterHeight);
            string right = GetHeaderText(FooterRight, httpContext, FooterHeight);
            return $"{left}{center}{right}";
        }

        public string GetHeaderText(int option, IHttpContextAccessor httpContext, int height)
        {
            switch (option)
            {
                case 1:
                    return $"<img style='height:{height}px; padding-top: 5px; width: 33%;' src='https://{httpContext.HttpContext.Request.Host.Value}/img/transparent.png' />";
                case 2:
                    return $"<img style='height:{height}px; padding-top: 5px; width: 33%;' src='https://{httpContext.HttpContext.Request.Host.Value}/img/transparent.png' />";
                case 3:
                    return $"<img style='height:{height}px; padding-top: 5px; width: 33%;' src='https://{httpContext.HttpContext.Request.Host.Value}/img/transparent.png' />";
                case 4:
                    return $"<img style='height:{height}px; padding-top: 5px; width: 33%;' src='https://{httpContext.HttpContext.Request.Host.Value}/api/logo/{FirmID}' />";
                default:
                    return "";
            }
        }

        private string GenerateOL(int counter)
        {
            string retString = string.Empty;
            for (int i = 1; i <= counter; i++)
            {
                retString += "ol ";
            }
            return retString;
        }

        private string GetPadding(int counter)
        {
            switch (counter)
            {
                case 1:
                    return "16px";
                case 2:
                case 3:
                    return "32px";
                case 4:
                case 5:
                    return "48px";
                case 6:
                case 7:
                default:
                    return "64px";
            }
        }

        private string GenerateMarker(int counter, int type)
        {
            string typeStr = "decimal";
            switch (type)
            {
                case 0:
                default:
                    typeStr = "decimal";
                    break;
                case 1:
                    typeStr = "lower-roman";
                    break;
                case 2:
                    typeStr = "upper-roman";
                    break;
                case 3:
                    typeStr = "lower-alpha";
                    break;
                case 4:
                    typeStr = "upper-alpha";
                    break;
            }

            string retString = string.Empty;
            for (int i = 1; i <= counter - 1; i++)
            {
                retString += $"counter(number{i}, {typeStr}) \".\" ";
            }
            if (counter > 1)
                retString += $"counter(number{counter}, {typeStr}) \" \" ";
            else
                retString += $"counter(number{counter}, {typeStr}) \". \" ";
            return retString;
        }

        public async Task ActivateBranding(IJSRuntime jsRuntime, NavigationManager mngr)
        {
            if (FirmID != Guid.Empty)
            {
                await jsRuntime.InvokeAsync<string>("SetPropertyValue", new object[] { "--BackgroundImg", $"url('/api/uploads/{FirmID}-Bg.png')" });
                await jsRuntime.InvokeAsync<string>("SetPropertyValue", new object[] { "--LogoImg", $"url('/api/uploads/{FirmID}-Logo.png')" });
                if (mngr.Uri.ToUpper().Contains("STORE"))
                    await jsRuntime.InvokeAsync<string>("SetPropertyValue", new object[] { "--BackgroundImg", $"url('/api/uploads/{FirmID}-OnlineBg.png')" });
                else
                    await jsRuntime.InvokeAsync<string>("SetPropertyValue", new object[] { "--BackgroundImg", $"url('/api/uploads/{FirmID}-Bg.png')" });
            }
            else
            {
                await jsRuntime.InvokeAsync<string>("SetPropertyValue", new object[] { "--LogoImg", $"url('/img/Logo2.png')" });
                if (mngr.Uri.ToUpper().Contains("STORE"))
                    await jsRuntime.InvokeAsync<string>("SetPropertyValue", new object[] { "--BackgroundImg", $"url('/api/uploads/{FirmID}-OnlineBg.png')" });
                else
                    await jsRuntime.InvokeAsync<string>("SetPropertyValue", new object[] { "--BackgroundImg", $"url('/img/Background.jpg')" });
            }
            await jsRuntime.InvokeAsync<string>("SetPropertyValue", new object[] { "--ButtonColor", ButtonColor });
            await jsRuntime.InvokeAsync<string>("SetPropertyValue", new object[] { "--ButtonFontColor", ButtonFontColor });
            await jsRuntime.InvokeAsync<string>("SetPropertyValue", new object[] { "--HeadingColor", HeadingColor });
            await jsRuntime.InvokeAsync<string>("SetPropertyValue", new object[] { "--MenuHeadingColor", MenuHeadingColor });
            await jsRuntime.InvokeAsync<string>("SetPropertyValue", new object[] { "--MenuFontColor", MenuFontColor });
            await jsRuntime.InvokeAsync<string>("SetPropertyValue", new object[] { "--MenuBackgroundColor", MenuBackgroundColor });  
        }
    }

    //Color
    //Font
    //Size

}
