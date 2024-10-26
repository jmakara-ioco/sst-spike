using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VezaVI.Light.Shared;

namespace VezaVI.Light.ServerExtensions
{
    public class VezaReportBase : IVezaReportBase
    {
        public readonly DbContext _context;
        public readonly ServiceCollectionHelper _helper;
        public readonly IHttpContextAccessor _environment;

        public VezaReportBase(DbContext context, ServiceCollectionHelper helper, IHttpContextAccessor environment)
        {
            _context = context;
            _helper = helper;
            _environment = environment;
        }

        public string GenerateReport(VezaReportParamCollection reportParams)
        {
            return GenerateHtml(reportParams);
        }

        public virtual string GenerateHtml(VezaReportParamCollection reportParams)
        {
            return string.Empty;
        }

        public byte[] Export(VezaReportParamCollection reportParams)
        {
            
            return GenerateExport(reportParams);
        }

        public virtual byte[] GenerateExport(VezaReportParamCollection reportParams)
        {
            return new byte[0];
        }

    }
}
