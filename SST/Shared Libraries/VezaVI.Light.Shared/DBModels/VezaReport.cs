using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VezaVI.Light.Shared
{
    public class VezaReport : VezaVIGuidRecordBase
    {
        public string Name { get; set; }

        public string Caption { get; set; }

        public string ClassType { get; set; }
        public ICollection<VezaReportCriteria> Criteria { get; set; }
    }
}
