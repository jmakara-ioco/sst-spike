using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SST.Server.Controllers
{
    [ApiController]
    public class FontController : ControllerBase
    {
        [HttpGet]
        [Route("api/GetAllFonts")]
        public async Task<IActionResult> GetAllFonts()
        {
            List<string> fonts = new List<string>();
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            foreach (FontFamily font in installedFontCollection.Families) 
            {
                fonts.Add(font.Name);

            }
            return Ok(fonts);
        }
    }
}
