using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sulfur.Models;

namespace Sulfur
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorrentFileController : ControllerBase
    {
        // POST api/TorrentFile
        //Post a JSON including the torrent url
        [HttpPost]
        public ActionResult<string> PostUrlPayload(UrlPayload url)
        {
            //ActionResult is the base class for various results for example JSONResult or Result
            //You can return a various amount of things.

            //Return the url value in the payload
            return url.Url;
        }
    }
}