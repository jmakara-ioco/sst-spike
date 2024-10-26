using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VezaVI.Light.Shared;

namespace VezaVI.Light.ServerExtensions
{
    public class VezaGridReportBase : VezaReportBase
    {
        public VezaGridReportBase(DbContext context, ServiceCollectionHelper helper, IHttpContextAccessor environment) : base(context, helper, environment)
        {
            
        }

        public override string GenerateHtml(VezaReportParamCollection reportParams)
        {
            var result = GenerateData(reportParams);
            StringBuilder htmlResult = new StringBuilder();

            int linecount = result.Lines.Count;

            htmlResult = new StringBuilder();
            StringBuilder[] htmlResult_Lines = new StringBuilder[linecount];

            htmlResult.Append("<!DOCTYPE html>");
            htmlResult.Append("<html>");
            htmlResult.Append("<head>");
            htmlResult.Append($"<title>{result.Header.ReportName}</title>");
            htmlResult.Append("<style>");
            htmlResult.Append(".Reporting table, th, td ");
            htmlResult.Append("{");
            htmlResult.Append("border: 1px solid black;");
            htmlResult.Append("border-collapse: collapse;");
            htmlResult.Append("}");
            htmlResult.Append("</style>");
            htmlResult.Append("</head>");
            htmlResult.Append("<body>");

            htmlResult.Append("<div class=\"Reporting\">");
            htmlResult.Append("<h2>");
            htmlResult.Append(result.Header.ReportCaption);
            htmlResult.Append("</h2>");

            htmlResult.Append("<table>");
            htmlResult.Append("<tr>");

            foreach (var col in result.Columns.OrderBy(c => c.Index))
            {
                htmlResult.Append("<th>");
                htmlResult.Append(col.Caption);
                htmlResult.Append("</th>");

                for (int lineno = 0; lineno < linecount; lineno++)
                {
                    string lineValue = result.Lines[lineno][col.Name];
                    if (htmlResult_Lines[lineno] == null)
                        htmlResult_Lines[lineno] = new StringBuilder();
                    htmlResult_Lines[lineno].Append("<td>");
                    htmlResult_Lines[lineno].Append(lineValue);
                    htmlResult_Lines[lineno].Append("</td>");
                }
            }
            htmlResult.Append("</tr>");

            foreach (var line in htmlResult_Lines)
            {
                htmlResult.Append("<tr>");
                htmlResult.Append(line.ToString());
                htmlResult.Append("</tr>");
            }

            htmlResult.Append("</table>");
            htmlResult.Append("</div>");
            htmlResult.Append("</body>");
            htmlResult.Append("</html>");

            return htmlResult.ToString();
        }

        public virtual VezaReportResult GenerateData(VezaReportParamCollection Params)
        {
            return new VezaReportResult();
        }

        /*public override byte[] GenerateExport(VezaReportParamCollection reportParams)
        {
            var converter = _helper.GetInstanceOf<IConverter>();

            string html = GenerateHtml(reportParams);
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = html,
                WebSettings = { DefaultEncoding = "utf-8" },
                //HeaderSettings = { FontName = doc.HeadersAndFooters[7], FontSize = 9, Left = doc.HeadersAndFooters[1], Center = doc.HeadersAndFooters[2], Right = doc.HeadersAndFooters[3], Line = Convert.ToBoolean(doc.HeadersAndFooters[8]) },
                //FooterSettings = { FontName = doc.HeadersAndFooters[7], FontSize = 9, Line = Convert.ToBoolean(doc.HeadersAndFooters[9]), Left = doc.HeadersAndFooters[4], Center = doc.HeadersAndFooters[5], Right = doc.HeadersAndFooters[6] }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file = converter.Convert(pdf);
            return file;
        }*/
    }
}
