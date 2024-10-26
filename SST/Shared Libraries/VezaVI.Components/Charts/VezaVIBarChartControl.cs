using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VezaVI.Light.Shared;
using VezaVI.Light.Components;

namespace VezaVI.Light.Components
{
    public abstract class VezaVIBarChartControl : VezaVIChartControl
    {
        public virtual async Task<VezaSerie> LoadChartData()
        {
            return new VezaSerie();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var seq = 0;
            builder.OpenElement(seq, "figure");
            builder.AddAttribute(++seq, "class", "vi-horizontal-bar-chart");
            builder.OpenElement(++seq, "div");
            builder.AddAttribute(++seq, "class", "main");

            //string[] inputDataArr = Serie. InputData.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] inputLabelsArr = Serie.Legends.ToArray();
            double boundHeight = 100.0;
            double boundWidth = 150.0;

            string[] colors = GetColours();
            
            VezaSvg svg = new VezaSvg() { { "class", "svg" }, { "width", "100%" }, { "height", "100%" }, { "viewBox", "0 0 150 100" } };
            //Rectangle rect = new Rectangle() { { "class", "background-rect" }, { "width", "100%" }, { "height", "100%" }, { "fill", "white" }, { "stroke", "gray" }, {"stroke-width", "0.5" } };
            VezaRectangle rect = new VezaRectangle() { { "class", "vi-background-rect" } };
            svg.AddItems(rect);

            int numHorizontalLines = 10;
            int numVerticalLines = 10;
            double verticalStartSpace = 10.0;
            double horizontalStartSpace = 30.0;
            double verticalEndSpace = 5.0;
            double horizontalEndSpace = 20.0;
            double gridYUnits = 10;
            double gridXUnits = 10;
            bool skipLastVerticalLine = false;
            bool skipLastHorizontalLine = false;

            double verticalSpace = (boundHeight - verticalStartSpace - verticalEndSpace) / (numHorizontalLines);
            double horizontalSpace = (boundWidth - horizontalStartSpace - horizontalEndSpace) / (numVerticalLines);

            double totalGridWidth = ((double)(numVerticalLines)) * horizontalSpace;
            double totalGridHeight = ((double)(numHorizontalLines)) * verticalSpace;
            System.Diagnostics.Debug.WriteLine("TotalGridHeight:" + totalGridHeight + ":" + verticalSpace);
                        
            //Vertical Lines            
            double x = horizontalStartSpace;
            double startGridX = 0;
            for (int counter = 0; counter <= numVerticalLines; counter++)
            {
                if (counter == numVerticalLines && skipLastVerticalLine)
                    continue;

                VezaPath path = new VezaPath() { { "class", "vi-vertical-grid-lines" }, { "d", "M " + x.ToString() + " " + (boundHeight - verticalStartSpace).ToString() + " L " + x.ToString() + " " + (verticalEndSpace).ToString() } };
                VezaChartLabel label = new VezaChartLabel() { { "class", "vi-y-axis-labels" }, { "x", x.ToString() }, { "y", (boundHeight - verticalStartSpace + 5).ToString() }, { "content", (startGridX).ToString() } };

                startGridX = startGridX + gridXUnits;

                svg.AddItems(path, label);
                x = x + horizontalSpace;
            }

            //Horizontal Lines

            double y = verticalStartSpace;
            double startGridY = 0;
            var i = 0;
            for (int counter = 0; counter <= numHorizontalLines; counter++)
            {
                System.Diagnostics.Debug.WriteLine("i:" + i);
                if (counter == numHorizontalLines && skipLastHorizontalLine)
                {
                    continue;
                }

                VezaPath path = new VezaPath() { { "class", "vi-horizontal-grid-lines" }, { "d", "M " + (horizontalStartSpace).ToString() + " " + (boundHeight - y).ToString() + " L " + (horizontalStartSpace + numHorizontalLines * gridXUnits).ToString() + " " + (boundHeight - y).ToString() } };
                string xLabels = "";
                if (counter < inputLabelsArr.Length)
                    xLabels = inputLabelsArr[counter];
                VezaChartLabel label = new VezaChartLabel() { { "class", "vi-x-axis-labels" }, { "x", (horizontalStartSpace - 2).ToString() }, { "y", (boundHeight - y).ToString() }, { "content", xLabels } };


                System.Diagnostics.Debug.WriteLine("z:" + i);
                if (counter == 0)
                    svg.AddItems(path, label);
                if (i < (inputLabelsArr.Length))
                {
                    var value = Serie.GetValue(inputLabelsArr[counter]);
                    //Rectangle bar = new Rectangle() { { "fill", "#ce4b99" }, { "x", (horizontalStartSpace).ToString() }, { "y", (boundHeight - y - 5).ToString() }, { "width", inputDataArrDouble[i].ToString() + "px" }, { "height", "5px" } };
                    VezaRectangle bar = new VezaRectangle() { { "class", "vi-bar" }, { "x", (horizontalStartSpace).ToString() }, { "y", (boundHeight - y - 5).ToString() }, { "width", value + "px" }, { "height", "5px" } };
                    svg.AddItems(label, bar);
                    i++;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("label");
                    if (counter < numHorizontalLines)
                        svg.AddItems(label);
                }

                System.Diagnostics.Debug.WriteLine("Y:" + y);

                y = y + verticalSpace;
                startGridY = startGridY + gridYUnits;
            }


            VezaBlazorRenderer blazorRenderer = new VezaBlazorRenderer();
            blazorRenderer.Draw(seq, builder, svg);

            builder.CloseElement();
            builder.CloseElement();
        
        }
    }
}
