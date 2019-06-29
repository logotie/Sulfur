using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sulfur.Constants;
using Sulfur.Models;
using Sulfur.Services.UrlFileDownloadActions;
using Sulfur.Services.UrlHeaderActions;

namespace Sulfur
{
    [Route("[controller]")]
    [ApiController]
    public class TorrentFileController : ControllerBase
    {
        private readonly IUrlActionService _urlActionService;
        private readonly IUrlFileDownloadService _urlFileDownloadService;

        public TorrentFileController(IUrlActionService urlActionService, IUrlFileDownloadService urlFileDownloadService)
        {
            _urlActionService = urlActionService;
            _urlFileDownloadService = urlFileDownloadService;
        }

        // POST api/TorrentFile
        //Post a JSON including the torrent url
        [HttpPost]
        public ActionResult<GuidResult> PostUrlPayload(UrlPayload url)
        {
            //Access HTTP Header
            string headerAuthToken = Request.Headers["Authorization"];

            //Checks if it is possible to bind the values in the request to the model.
            //If url is null, means it was unable to bind the model
            if (!ModelState.IsValid || !_urlActionService.SuccessfulMatchOnHeaderToken(headerAuthToken))
            {
                //Returns a 400 bad request
                return BadRequest(ModelState);
            }

            //process the url using the urlfiledownload service
            var tupleResponse = _urlFileDownloadService.ProcessUrl(url.Url);

            //pass success or fail to urlactionservice and get back guid payload
            GuidResult result = _urlActionService.GenerateGuidPayload(tupleResponse.Item1, tupleResponse.Item2);

            return result;
        }
    }
}