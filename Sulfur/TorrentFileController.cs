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
        // GET api/TorrentFile
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}