using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Sulfur;
using Sulfur.Constants;
using Sulfur.Models;
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
        //Need to fix the tests to somehow mock the header 
        [Fact]
        public void GuidGeneratePostRequestTest()
        {
            //Setup
            var mockUrlPayloadRequest = new Mock<UrlPayload>();
            var mockUrlHeaderService = new Mock<UrlActionService>();

            //Sets up the url field to return google.com
            mockUrlPayloadRequest.Setup(s => s.Url).Returns("google.com");

            //var request = new HttpRequestMessage(HttpMethod.Post, "http://stackoverflow");
            //request.Headers.Add(WebConstants.AuthHeaderKeyValue, ServiceConstants.AuthTokenPassword);

            var controller = new TorrentFileController(mockUrlHeaderService.Object);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.Request.Headers.Add("Authorization", ServiceConstants.AuthTokenPassword); 

            //Act
            var result = controller.PostUrlPayload(mockUrlPayloadRequest.Object);

            //Assert that it is of the type GuidResult
            Assert.IsType<ActionResult<GuidResult>>(result);

            //Assert that the Guid Payload string is not null or empty
            Assert.False(String.IsNullOrEmpty(result.Value.Id));
        }
    }
}
