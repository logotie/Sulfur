using Moq;
using Sulfur.Services.UrlTorrentDownloadActions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SulfurXunitTests
{
    public class UrlTorrentServiceTests
    {
        private readonly IUrlTorrentService urlTorrentService;
        public UrlTorrentServiceTests()
        {
            var mock = new Mock<UrlTorrentService>();
            urlTorrentService = mock.Object;
        }

        [Fact]
        public void TestWhetherTorrentContainsAnyAudioFiles()
        {

        }
    }
}
