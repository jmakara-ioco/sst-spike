using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SST.Server
{
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;
        public UploadController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        [HttpPost]
        [Route("api/uploads")]
        public async Task Post()
        {
            if (HttpContext.Request.Form.Files.Any())
            {
                foreach (var file in HttpContext.Request.Form.Files)
                {
                    var path = Path.Combine(environment.ContentRootPath, "uploads", file.FileName);
                    using (var stream = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
        }

        [HttpGet]
        [Route("api/uploads/{fileName}")]
        public async Task<IActionResult> Get(string fileName)
        {
            var path = Path.Combine(environment.ContentRootPath, "uploads", fileName);
            if (System.IO.File.Exists(path))
            {
                var bytes = System.IO.File.ReadAllBytes(path);
                return File(bytes, "image/png");
            }
            return File(new byte[0], "image/png");
        }
    }
}
