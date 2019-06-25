using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Sulfur;
using Sulfur.Models;
using Sulfur.Models.Db;
using Sulfur.Services.UrlPayloadActions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace SulfurXunitTests
{
    public class TorrentFileControllerTests
    {
        [Fact]
        public void GuidGeneratePostRequestTest()
        {
            //Setup
            var mockContext = new Mock<IDbContext>();
            var mockUrlPayloadService = new Mock<UrlPayloadService>();
            var mockUrlPayloadRequest = new Mock<UrlPayload>();
            
            //Sets up the url field to return google.com
            mockUrlPayloadRequest.Setup(s => s.Url).Returns("google.com");

            var controller = new TorrentFileController(mockContext.Object, mockUrlPayloadService.Object);

            //Act
            var result = controller.PostUrlPayload(mockUrlPayloadRequest.Object);

            //Assert that it is of the type GuidResult
            Assert.IsType<ActionResult<GuidResult>>(result);

            //Assert that the Guid Payload string is not null or empty
            Assert.False(String.IsNullOrEmpty(result.Value.Id));
        }
    }
}
