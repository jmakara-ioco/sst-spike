using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Shared
{
    public interface IReportExporter
    {
        byte[] Generate(VezaReportParamCollection reportParams);
        string GenerateHtml(VezaReportParamCollection reportParams);
    }
}
