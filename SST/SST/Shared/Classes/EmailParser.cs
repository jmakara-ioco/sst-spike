using System;
using System.Collections.Generic;
using System.Text;

namespace SST.Shared.Classes
{
    public class EmailParser
    {
        public static string Parse(EmailTemplate template, IDictionary<string, string> keys)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<table>");
            if (!string.IsNullOrEmpty(template.HeaderImage)) {
                
            }
            string body = template.Body;
            foreach (var key in keys)
            {
                body = body.Replace(key.Key, key.Value);
            }
            //Enter
            builder.Append(body);
            if (!string.IsNullOrEmpty(template.FooterImage))
            {

            }
            builder.Append("</table>");
            return builder.ToString();
        }
    }
}
