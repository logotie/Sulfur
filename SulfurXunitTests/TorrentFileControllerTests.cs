﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Sulfur;
using Sulfur.Constants;
using Sulfur.Models;
using Sulfur.Services.UrlFileDownloadActions;
using Sulfur.Services.UrlHeaderActions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;


namespace SulfurXunitTests
{
    public class TorrentFileControllerTests
    {
        //We put a valid url 'www.google.com', it should fail with the error 'file incorrect format'
        //Signifying a file was downloaded but it was not a torrent file.
        [Fact]
        public void GuidGeneratePostRequestTest()
        {
            //Setup
            var mockUrlPayloadRequest = new Mock<UrlPayload>();
            var mockUrlHeaderService = new Mock<UrlActionService>();
            var mockUrlFileDownloadService = new Mock<UrlFileDownloadService>();

            //Sets up the url field to return google.com
            mockUrlPayloadRequest.Setup(s => s.Url).Returns("https://google.com");

            var controller = new TorrentFileController(mockUrlHeaderService.Object);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.Request.Headers.Add("Authorization", ServiceConstants.AuthTokenPassword); 

            //Act
            var result = controller.PostUrlPayload(mockUrlPayloadRequest.Object);

            //Assert that it is of the type GuidResult
            Assert.IsType<ActionResult<GuidResult>>(result);

            //Assert that the Guid Payload string is not null or empty
            Assert.True(String.IsNullOrEmpty(result.Value.Id));


            bool resultMatch = false;
            if (result.Value.error.Equals(ServiceConstants.FileIncorrectFormat))
                resultMatch = true;

            Assert.True(resultMatch);

            Assert.True(Boolean.Parse(result.Value.success));
        }
    }
}
