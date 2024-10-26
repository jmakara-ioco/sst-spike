using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.ServerExtensions
{
    public class VezaReportFactory
    {
        
        public static VezaReportBase FromType(Type tp, DbContext context, ServiceCollectionHelper helper, IHttpContextAccessor environment)
        {
            if (typeof(VezaReportBase).IsAssignableFrom(tp))
            {
                var instance = (VezaReportBase)Activator.CreateInstance(tp, new object[] { context, helper, environment });
                return instance;
            }
            else
                throw new Exception("Invalid Report Type, cannot create report");
        }
    }
}
