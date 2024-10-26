using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Shared
{
    public interface IVezaReportBase
    {
        string GenerateReport(VezaReportParamCollection reportParams);
        byte[] Export(VezaReportParamCollection reportParams);
    }
}
