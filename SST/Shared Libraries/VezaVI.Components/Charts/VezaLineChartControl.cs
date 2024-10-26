using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VezaVI.Light.Shared;

namespace VezaVI.Light.Components
{
    public abstract class VezaLineChartControl : OwningComponentBase
    {
        public VezaMultiSerie Serie { get; private set; }

        protected async override Task OnInitializedAsync()
        {
            Serie = await LoadChartData();
            StateHasChanged();
        }

        public virtual async Task<VezaMultiSerie> LoadChartData()
        {
            return new VezaMultiSerie();
        }

        public virtual string[] GetColours()
        {
            return new string[] { "#f2c40f", "#fdbb30", "#0f0f0f", "#242020", "#524e4e", "#f2cc0f" };
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var seq = 0;
            //builder.OpenElement(seq, "figure");
            builder.OpenElement(++seq, "div");
            builder.AddAttribute(++seq, "class", "vi-full-line card");

            if (Serie != null)
            {
                if (Serie.Name != string.Empty)
                {
                    builder.OpenElement(++seq, "div");
                    builder.AddAttribute(++seq, "class", "vi-card-header");
                    builder.AddContent(++seq, Serie.Name);
                    builder.CloseElement();
                }

                builder.OpenElement(++seq, "div");
                builder.AddAttribute(++seq, "class", "linechart-main text-center");

                //string[] colors = GetColours();

                VezaSvg svg = new VezaSvg() { { "viewBox", "0 0 100 100" } };
                VezaRectangle rect = new VezaRectangle() { { "width", "100%" }, { "height", "100%" }, { "fill", "none" }/*, { "stroke", "gray" }, { "stroke-width", "0.5" }*/ };
                //Rectangle rect = new Rectangle() { { "width", "100%" }, { "height", "100%" }, { "fill", "cyan" }};
                svg.AddItems(rect);

                double valueCount = Serie.GetColumnCount();
                double maxCount = Serie.GetMaxValue();

                int numHorizontalLines = 10;
                int numVerticalLines = (int)Math.Ceiling(valueCount);
                double boundHeight = 100.0;
                double boundWidth = 100.0;
                double verticalStartSpace = 10.0;
                double horizontalStartSpace = 10.0;
                double verticalEndSpace = 5.0;
                double horizontalEndSpace = 5.0;
                double gridYUnits = Math.Ceiling(maxCount / 10.0);
                double gridXUnits = 1;
                bool skipLastVerticalLine = true;
                bool skipLastHorizontalLine = true;

                double verticalSpace = (boundHeight - verticalStartSpace - verticalEndSpace) / (numHorizontalLines - 1);
                double horizontalSpace = (boundWidth - horizontalStartSpace - horizontalEndSpace) / (numVerticalLines - 1);

                double totalGridWidth = ((double)(numVerticalLines - 1)) * horizontalSpace;
                double totalGridHeight = ((double)(numHorizontalLines - 1)) * verticalSpace;
                System.Diagnostics.Debug.WriteLine("TotalGridHeight:" + totalGridHeight + ":" + verticalSpace);

                //Horizontal Lines
                double y = verticalStartSpace;
                double startGridY = 0;
                for (int counter = 0; counter < numHorizontalLines; counter++)
                {
                    if (counter == numHorizontalLines - 1 && skipLastHorizontalLine)
                        continue;

                    VezaPath path = new VezaPath() { { "fill", "none" }, { "stroke", "gray" }, { "stroke-width", "0.2" }, { "d", "M " + horizontalStartSpace.ToString().Replace(",", ".") + " " + (boundHeight - y).ToString().Replace(",", ".") + " L " + (boundWidth - horizontalEndSpace).ToString().Replace(",", ".") + " " + (boundHeight - y).ToString().Replace(",", ".") } };
                    VezaChartLabel label = new VezaChartLabel() { { "x", (horizontalStartSpace - 2).ToString().Replace(",", ".") }, { "y", (boundHeight - y).ToString().Replace(",", ".") }, { "font-size", "4px" }, { "text-anchor", "end" }, { "content", (startGridY).ToString().Replace(",", ".") } };
                    svg.AddItems(path, label);
                    System.Diagnostics.Debug.WriteLine("Y:" + y);

                    y = y + verticalSpace;
                    startGridY = startGridY + gridYUnits;
                }

                //Chart Line
                double gridx = 0, gridy = 0;
                gridx = horizontalStartSpace;
                gridy = boundHeight - verticalStartSpace;
                int colorcounter = 0;
                foreach (string key in Serie.Legends)
                {
                    string chartLine = "";
                    double gridValueX = 0;
                    double gridValueY = 0;
                    bool firstTime = true;

                    foreach (double i in Serie.GetValue(key))
                    {
                        if (firstTime)
                        {
                            chartLine = chartLine + "M ";
                            firstTime = false;
                            gridValueX = horizontalStartSpace;
                            gridValueY = verticalStartSpace;
                            double gridValue = ((double)i) * verticalSpace / gridYUnits;
                            gridValueY = boundHeight - (gridValueY + gridValue);
                            chartLine = chartLine + gridValueX.ToString().Replace(",", ".") + " " + gridValueY.ToString().Replace(",", ".");
                        }
                        else
                        {
                            chartLine = chartLine + " L ";
                            gridValueX = gridValueX + horizontalSpace;
                            gridValueY = verticalStartSpace;
                            double gridValue = ((double)i) * verticalSpace / gridYUnits;
                            gridValueY = boundHeight - (gridValueY + gridValue);
                            chartLine = chartLine + gridValueX.ToString().Replace(",", ".") + " " + gridValueY.ToString().Replace(",", ".");
                        }
                    }
                    //System.Diagnostics.Debug.WriteLine("CL:" + chartLine);
                    VezaPath linepath = new VezaPath() { { "fill", "none" }, { "stroke", GetColor(colorcounter++) }, { "stroke-width", "1.0" }, { "d", chartLine } };
                    svg.AddItems(linepath);

                }

                //Vertical Lines            
                double x = horizontalStartSpace;
                double startGridX = 0;
                for (int counter = 0; counter < numVerticalLines; counter++)
                {
                    if (counter == numVerticalLines - 1 && skipLastVerticalLine)
                        continue;

                    VezaPath path = new VezaPath() { { "fill", "none" }/*, { "stroke", "gray" }, { "stroke-width", "0.2" }, { "d", "M " + x.ToString() + " " + (boundHeight - verticalStartSpace).ToString() + " L " + x.ToString() + " " + (verticalEndSpace).ToString() }*/ };
                    VezaChartLabel label = new VezaChartLabel() { { "x", x.ToString().Replace(",", ".") }, { "y", (boundHeight - verticalStartSpace + 5).ToString().Replace(",", ".") }, { "font-size", "4px" }, { "text-anchor", "middle" }, { "content", (startGridX).ToString().Replace(",", ".") } };
                    startGridX = startGridX + gridXUnits;
                    if (counter % 5 == 0)
                    {
                        svg.AddItems(path, label);
                    }
                    x = x + horizontalSpace;

                }

                VezaBlazorRenderer blazorRenderer = new VezaBlazorRenderer();
                blazorRenderer.Draw(seq, builder, svg);

                builder.OpenElement(++seq, "div");
                builder.AddAttribute(++seq, "class", "mt-4 text-center small");
                colorcounter = 0;
                foreach (string iData in Serie.Legends)
                {
                    builder.OpenElement(++seq, "span");
                    builder.AddAttribute(++seq, "class", "mr-2");
                    builder.AddAttribute(++seq, "style", "color:" + GetColor(colorcounter) + ";font-size: 25px;vertical-align: sub; white-space: nowrap;");
                    builder.AddContent(++seq, "●");

                    builder.OpenElement(++seq, "span");
                    builder.AddAttribute(++seq, "class", "mr-2");
                    builder.AddAttribute(++seq, "style", $"display: inline-block;  color: black; font-size: 18px;");
                    builder.AddContent(++seq, iData);
                    builder.CloseElement();

                    builder.CloseElement();
                    colorcounter++;
                }

                builder.CloseElement();
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
