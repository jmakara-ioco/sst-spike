using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VezaVI.Light.Shared
{
    [Serializable]
    public class VezaReportParam
    {
        public string Name { get; set; }

        public object Value { get; set; }
    }
    
    public enum ReportFormat
    {
        HtmlContent,
        PDF
    }

    [Serializable]
    public class VezaReportParamCollection
    {
        public Guid ReportID { get; set; }
        public ReportFormat ReportFormat { get; set; } = ReportFormat.HtmlContent;

        public string ContentType
        {
            get
            {
                switch (ReportFormat)
                {
                    case ReportFormat.PDF:
                        return "application/pdf";
                    default:
                        return "text/html";
                }
            }
        }

        public List<VezaReportParam> Parameters { get; set; } = new List<VezaReportParam>();

        public T TryGetValue<T>(string paramName, T defaultValue)
        {
            var value = Parameters.FirstOrDefault(x => x.Name == paramName);
            if (value != null)
                return (T)value.Value;
            return defaultValue;
        }

        public void SetValue<T>(string paramName, T value)
        {
            var listValue = Parameters.FirstOrDefault(x => x.Name == paramName);
            if (listValue != null)
                listValue.Value = value;
            else
                Parameters.Add(new VezaReportParam() { Name = paramName, Value = value });
        }
    }
}
