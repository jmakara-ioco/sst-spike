using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VezaVI.Light.Shared
{


    [Table("ReportCriteria")]
    public class VezaReportCriteria : VezaVIGuidRecordBase
    {
        public DataFieldType TypeOfField { get; set; } = (int)DataFieldType.Text;
        public string FieldName { get; set; }
        public string DisplayText { get; set; }
        public bool Required { get; set; }
        public string NullText { get; set; }
        public Guid ReportId { get; set; }
    }
    public enum DataFieldType
    {
        Text = 0,
        Numeric = 1,
        Boolean = 2,
        Date = 3
    }
}
