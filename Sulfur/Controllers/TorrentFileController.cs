using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sulfur.Constants;
using Sulfur.Models;
using Sulfur.Models.Db;
using Sulfur.Services.UrlPayloadActions;

namespace Sulfur
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorrentFileController : ControllerBase
    {
        private readonly IDbContext _context;
        private readonly IUrlPayloadService _urlPayloadService;

        public TorrentFileController(IDbContext context, IUrlPayloadService urlPayloadService)
        {
            _context = context;
            _urlPayloadService = urlPayloadService;
        }

        // POST api/TorrentFile
        //Post a JSON including the torrent url
        [HttpPost]
        public ActionResult<GuidResult> PostUrlPayload(UrlPayload url)
        {
            //Checks if it is possible to bind the values in the request to the model.
            if (!ModelState.IsValid)
            {
                //Returns a 400 bad request
                return BadRequest(ModelState);
            }

            //Access HTTP Header
            //string headerAuthToken = Request.Headers[WebConstants.AuthHeaderKeyValue];

           


            //ActionResult is the base class for various results for example JSONResult or Result
            //You can return a various amount of things.
            //Return a guid value from the post request
            return _urlPayloadService.GenerateGuidPayload();
        }
    }
}