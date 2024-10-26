using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Shared
{
    public class VezaReportResultLine
    {
        public Dictionary<string,string> LineValues { get; set; }

        public string this[string fieldName]
        {
            get
            {
                if(LineValues.ContainsKey(fieldName))
                {
                    return LineValues[fieldName];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (LineValues.ContainsKey(fieldName))
                {
                    
                    LineValues[fieldName] = value;
                }
                else
                {
                    LineValues.Add(fieldName, value);
                }
            }
        }
    }
}
