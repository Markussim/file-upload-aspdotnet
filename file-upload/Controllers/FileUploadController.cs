using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;


namespace file_upload.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileUploadController : ControllerBase
    {
        [HttpGet]
        public ActionResult FrontEnd()
        {
            return Content(System.IO.File.ReadAllText(@"./data/upload.html"), "text/html");
        }

        [HttpPost]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        public ActionResult Upload()
        {
            try
            {
                Microsoft.AspNetCore.Http.IFormFile file = Request.Form.Files[0];

                SaveFileUtils.SaveFile(file);

                return Content(file.ContentType);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);

                return StatusCode(500);
            }
        }
    }
}
