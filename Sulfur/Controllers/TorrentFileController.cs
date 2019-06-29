﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sulfur.Constants;
using Sulfur.Models;
using Sulfur.Services.UrlHeaderActions;

namespace Sulfur
{
    [Route("[controller]")]
    [ApiController]
    public class TorrentFileController : ControllerBase
    {
        private readonly IUrlActionService _urlActionService;

        public TorrentFileController(IUrlActionService urlActionService)
        {
            _urlActionService = urlActionService;
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

            //pass success or fail to urlactionservice and get back guid payload

            //return guid payload

            //ActionResult is the base class for various results for example JSONResult or Result
            //You can return a various amount of things.
            //Return a guid value from the post request
            return _urlActionService.GenerateGuidPayload();
        }
    }
}