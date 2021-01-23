using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
                var file = Request.Form.Files[0];

                var returnString = file.Length.ToString();

                return Content(returnString);

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);

                return StatusCode(500);
            }
        }
    }
}
