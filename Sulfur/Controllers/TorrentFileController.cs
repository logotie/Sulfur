using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sulfur
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorrentFileController : ControllerBase
    {
        // POST api/TorrentFile
        [HttpPost]
        public ActionResult<IEnumerable<string>> Get()
        {
            //ActionResult is the base class for various results for example JSONResult or Result
            //You can return a various amount of things.
            return new string[] { "value1", "value2" };
        }
    }
}