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
        public void UrlDownloadInvalidUrlTest()
        {
            String invalidUrl = "https://www.google";

            Assert.False(urlFileDownloadService.ProcessUrl(invalidUrl).Item1);
        }

        [Fact]
        public void UrlDownloadInvalidUrlDownloadFileTest()
        {
            String fileIsNotTorrentFile = "https://www.google.com";

            Assert.False(urlFileDownloadService.ProcessUrl(fileIsNotTorrentFile).Item1);
        }

        [Fact]
        public void SuccessUrlDownloadFileTest()
        {
            String success = "http://releases.ubuntu.com/19.04/ubuntu-19.04-desktop-amd64.iso.torrent";

            Assert.True(urlFileDownloadService.ProcessUrl(success).Item1);
        }

        [Fact]
        public void DoesTorrentContainAudioFileTest()
        {
            
        }
    }
}
