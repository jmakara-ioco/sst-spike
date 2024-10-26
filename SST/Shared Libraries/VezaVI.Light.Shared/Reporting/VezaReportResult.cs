using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VezaVI.Light.Shared
{
    public class VezaReportResult
    {
        public VezaReportResult() { }

        public VezaReportResultHeader Header { get; set; }
        public IList<VezaReportResultColumn> Columns { get; set; }

        public IList<VezaReportResultLine> Lines { get; set; }
    }
}
