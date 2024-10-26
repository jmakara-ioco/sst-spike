using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SST.Server
{
    public class TenantRule : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            var response = context.HttpContext.Response;
            var request = context.HttpContext.Request;

            if (request.Path.StartsWithSegments("/api"))
                return;
            if (request.Host.Host.Contains('.'))
            {
                string tenant = request.Host.Host.Substring(0, request.Host.Host.IndexOf('.'));
                string queryString = request.QueryString.Value;
                if (string.IsNullOrEmpty(queryString))
                    queryString = $"?Tenant={tenant}";
                else
                    queryString += $"&Tenant={tenant}";
                request.Headers[HeaderNames.Location] = request.Path + queryString;
                context.Result = RuleResult.SkipRemainingRules;
            }
        }
    }
}
