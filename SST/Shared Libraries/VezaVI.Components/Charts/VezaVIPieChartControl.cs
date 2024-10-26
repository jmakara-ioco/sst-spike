using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Components
{
    public abstract class VezaVIPieChartControl : VezaVIChartControl
    {
        private double pieRadius = 0.85;
        private void getCoordinatesForPercent(double percent, out double x, out double y)
        {
            //x = Math.Cos(2 * Math.PI * percent);
            //y = Math.Sin(2 * Math.PI * percent);
            x = pieRadius * Math.Cos(2 * Math.PI * percent);
            y = pieRadius * Math.Sin(2 * Math.PI * percent);
        }


        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var seq = 0;
            builder.OpenElement(++seq, "div");
            builder.AddAttribute(++seq, "class", "vi-full-line card");
            //builder.AddAttribute(++seq, "class", "card shadow h-100 py-2");

            /*Refresh*/
            builder.OpenElement(++seq, "div");
            builder.AddAttribute(++seq, "class", "card-refresh");
            builder.CloseElement();

            if (Serie != null)
            {
                if (Serie.Name != string.Empty)
                {
                    builder.OpenElement(++seq, "div");
                    builder.AddAttribute(++seq, "class", "vi-card-header vi-center-text");
                    builder.AddContent(++seq, Serie.Name);
                    builder.CloseElement();
                }

                builder.OpenElement(++seq, "div");
                builder.AddAttribute(++seq, "class", "card-body");

                builder.OpenElement(++seq, "div");
                builder.AddAttribute(++seq, "class", "piechart-main text-center");

                //string[] colors = GetColours();

                VezaSvg svg = new VezaSvg() { { "viewBox", "-1 -1 2 2" }, { "style", "transform: rotate(-0.25turn)" } };

                double x, y;
                double px = 0, py = 0;
                double totalPercent = 0;
                string prStr = pieRadius.ToString().Replace(",", ".");

                int counter = 0;
                foreach (string legend in Serie.Legends)
                {
                    double percent = Serie.GetValueAsPercentage(legend);
                    totalPercent = totalPercent + percent;
                    getCoordinatesForPercent(totalPercent, out x, out y);
                    VezaPath path = null;

                    //< path d = "M 0.85 0 A 0.85 0.85 0 1 1 0.8 -0.59 L 0 0" ></ path >
                    if (counter == 0)
                    {
                        if (percent > 0.5)
                            path = new VezaPath() { { "fill", GetColor(counter) }, { "d", "M " + prStr + " 0 A " + prStr + " " + prStr + " 0 1 1 " + x.ToString().Replace(",", ".") + " " + y.ToString().Replace(",", ".") + " L 0 0" } };
                        else
                            path = new VezaPath() { { "fill", GetColor(counter) }, { "d", "M " + prStr + " 0 A " + prStr + " " + prStr + " 0 0 1 " + x.ToString().Replace(",", ".") + " " + y.ToString().Replace(",", ".") + " L 0 0" } };
                    }
                    else
                    {
                        if (percent > 0.5)
                            path = new VezaPath() { { "fill", GetColor(counter) }, { "d", "M " + px.ToString().Replace(",", ".") + " " + py.ToString().Replace(",", ".") + " A " + prStr + " " + prStr + " 0 1 1 " + x.ToString().Replace(",", ".") + " " + y.ToString().Replace(",", ".") + " L 0 0" } };
                        else
                            path = new VezaPath() { { "fill", GetColor(counter) }, { "d", "M " + px.ToString().Replace(",", ".") + " " + py.ToString().Replace(",", ".") + " A " + prStr + " " + prStr + " 0 0 1 " + x.ToString().Replace(",", ".") + " " + y.ToString().Replace(",", ".") + " L 0 0" } };
                    }
                    svg.AddItems(path);
                    px = x; py = y;
                    counter++;
                }
                VezaBlazorRenderer blazorRenderer = new VezaBlazorRenderer();
                blazorRenderer.Draw(seq, builder, svg);

                builder.OpenElement(++seq, "div");
                builder.AddAttribute(++seq, "class", "mt-4 text-center small");

                counter = 0;
                foreach (string legend in Serie.Legends)
                {
                    
                    builder.OpenElement(++seq, "span");
                    builder.AddAttribute(++seq, "class", "mr-2");
                    builder.AddAttribute(++seq, "style", "color:" + GetColor(counter) + ";font-size: 25px;vertical-align: sub; white-space: nowrap;");
                    builder.AddContent(++seq, "●");
                    
                    builder.OpenElement(++seq, "span");
                    builder.AddAttribute(++seq, "class", "mr-2");
                    builder.AddAttribute(++seq, "style", $"display: inline-block; color: black; font-size: 18px;");
                    builder.AddContent(++seq, legend + " " + "(" + Serie.GetValue(legend) + ")");
                    builder.CloseElement();
                    
                    builder.CloseElement();
                    counter++;
                }

                builder.CloseElement();
                builder.CloseElement();
                builder.CloseElement();
            }
            else
            {
                builder.OpenElement(++seq, "div");
                builder.AddAttribute(++seq, "class", "piechart-main text-center");
                builder.AddContent(++seq, "Loading Data...");
                builder.CloseElement();
            }
            builder.CloseElement();
        }

        private string GetColor(int index)
        {
            string[] colors = GetColours();
            var ind = index % colors.Length;
            return colors[ind];
        }
    }
}
