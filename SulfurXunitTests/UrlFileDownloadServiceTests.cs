using Moq;
using Sulfur.Services.UrlFileDownloadActions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SulfurXunitTests
{
    public class UrlFileDownloadServiceTests
    {
        private readonly IUrlFileDownloadService urlFileDownloadService;
        public UrlFileDownloadServiceTests()
        {
            var mock = new Mock<UrlFileDownloadService>();
            urlFileDownloadService = mock.Object;
        }

        [Fact]
        public void UrlDownloadFileTest()
        {
            String validUrl = "https://www.google.com";
            String invalidUrl = "https://www.google";
            String invalidUrl2 = "https://google";

            Assert.True(actionService.ValidUrl(validUrl));
            Assert.False(actionService.ValidUrl(invalidUrl));
            Assert.False(actionService.ValidUrl(invalidUrl2));


        }
    }
}
