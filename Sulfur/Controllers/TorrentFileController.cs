using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sulfur.Models;
using Sulfur.Services.UrlPayload;

namespace Sulfur
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorrentFileController : ControllerBase
    {
        private readonly SulfurDbContext _context;
        private readonly IUrlPayloadService _urlPayloadService;

        public TorrentFileController(SulfurDbContext context, IUrlPayloadService urlPayloadService)
        {
            _context = context;
            _urlPayloadService = urlPayloadService;
        }

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