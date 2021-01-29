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
    public class GetFileController : ControllerBase
    {
        [HttpGet]
        public ActionResult FrontEnd()
        {
            return Content(System.IO.File.ReadAllText(@"./data/upload.html"));
        }
    }
}
