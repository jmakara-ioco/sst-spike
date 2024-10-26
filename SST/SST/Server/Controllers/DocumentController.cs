using DinkToPdf;
using DinkToPdf.Contracts;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SST.Server.Data;
using SST.Shared;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SST.Server.Controllers
{
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConverter _converter;
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _httpContext;

        public DocumentController(ApplicationDbContext context,
                               IConverter converter,
                               IWebHostEnvironment environment,
                               IHttpContextAccessor httpContext)
        {
            _context = context;
            _converter = converter;
            _environment = environment;
            _httpContext = httpContext;
        }

        [HttpGet]
        [Route("api/Header/{styleID}")]
        public async Task<IActionResult> Header(Guid styleID) {

            var stylesheet = await _context.FirmStylings.Include(x => x.Firm).FirstOrDefaultAsync(x => x.ID == styleID);
            return Content(stylesheet.GenerateHeader(_httpContext), "text/html");
        }

        [HttpGet]
        [Route("api/Footer/{styleID}")]
        public async Task<IActionResult> Footer(Guid styleID)
        {

            var stylesheet = await _context.FirmStylings.Include(x => x.Firm).FirstOrDefaultAsync(x => x.ID == styleID);
            return Content(stylesheet.GenerateFooter(_httpContext), "text/html");
        }

        [HttpGet]
        [Route("api/GeneratePDF/{historyID}")]
        public async Task<IActionResult> GeneratePDF(Guid historyID)
        {
            var doc = PDFDocument.GenerateTransaction(_context, historyID);
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = Convert.ToInt32(doc.HeadersAndFooters[10]), Bottom = Convert.ToInt32(doc.HeadersAndFooters[11])},
                DocumentTitle = "PDF Report"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = doc.Content,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = doc.HeadersAndFooters[7], FontSize = 9, Left = doc.HeadersAndFooters[1], Center = doc.HeadersAndFooters[2], Right = doc.HeadersAndFooters[3], Line = Convert.ToBoolean(doc.HeadersAndFooters[8]) },
                FooterSettings = { FontName = doc.HeadersAndFooters[7], FontSize = 9, Line = Convert.ToBoolean(doc.HeadersAndFooters[9]), Left = doc.HeadersAndFooters[4], Center = doc.HeadersAndFooters[5], Right = doc.HeadersAndFooters[6] }
            };
            //objectSettings.HeaderSettings.HtmUrl = $"https://{_httpContext.HttpContext.Request.Host.Value}/api/Header/" + doc.HeadersAndFooters[12];
            objectSettings.FooterSettings.HtmUrl = $"https://{_httpContext.HttpContext.Request.Host.Value}/api/Footer/" + doc.HeadersAndFooters[12];

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file = _converter.Convert(pdf);
            return File(file, "application/pdf");
        }

        [HttpGet]
        [Route("api/GenerateTemplatePDF/{templateID}")]
        public async Task<IActionResult> GenerateTemplatePDF(Guid templateID)
        {
            var doc = PDFDocument.GenerateTemplate(_context, templateID);
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = Convert.ToInt32(doc.HeadersAndFooters[10]), Bottom = Convert.ToInt32(doc.HeadersAndFooters[11]) },
                DocumentTitle = "PDF Report"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = doc.Content,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = doc.HeadersAndFooters[7], FontSize = 9, Left = doc.HeadersAndFooters[1], Center = doc.HeadersAndFooters[2], Right = doc.HeadersAndFooters[3], Line = Convert.ToBoolean(doc.HeadersAndFooters[8]) },
                FooterSettings = { FontName = doc.HeadersAndFooters[7], FontSize = 9, Line = Convert.ToBoolean(doc.HeadersAndFooters[9]), Left = doc.HeadersAndFooters[4], Center = doc.HeadersAndFooters[5], Right = doc.HeadersAndFooters[6] }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file = _converter.Convert(pdf);
            return File(file, "application/pdf");
        }

        [HttpGet]
        [Route("api/TestTemplate/{templateID}")]
        public async Task<IActionResult> TestTemplate(Guid templateID)
        {
            var doc = PDFDocument.GenerateTemplate(_context, templateID);
            return Content(doc.Content, "text/html");
        }

        [HttpGet]
        [Route("api/Test/{historyID}")]
        public async Task<IActionResult> Test(Guid historyID)
        {
            var doc = PDFDocument.GenerateTransaction(_context, historyID);
            return Content(doc.Content, "text/html");
        }

        [HttpGet]
        [Route("api/logo/{clientID}")]
        public async Task<IActionResult> GetLogo(Guid clientID)
        {
            /*var client = await _context.Customers.FirstOrDefaultAsync(x => x.ID == clientID);
            if (client != null)
            {*/
                var path = Path.Combine(_environment.ContentRootPath, "uploads", $"{clientID}-Logo.png");
                if (System.IO.File.Exists(path))
                {
                    var bytes = System.IO.File.ReadAllBytes(path);
                    return File(bytes, "image/png");
                }
            //}
            return File(new byte[0], "image/png");
        }
    }
}
