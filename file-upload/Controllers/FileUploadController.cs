using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore.Cors;


namespace file_upload.Controllers
{
    [ApiController]
    [Route("/")]
    public class FileUploadController : ControllerBase
    {
        String uploadHtml = System.IO.File.ReadAllText(@"./data/upload.html");

        [HttpGet]
        public ActionResult FrontEnd()
        {
            return Content(uploadHtml, "text/html");
        }


        [HttpPost]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        public ActionResult Upload()
        {
            
            try
            {
                Microsoft.AspNetCore.Http.IFormFile file = Request.Form.Files[0];

                return Content(SaveFileUtils.SaveFile(file));
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);

                return StatusCode(500);
            }
        }
    }
}
