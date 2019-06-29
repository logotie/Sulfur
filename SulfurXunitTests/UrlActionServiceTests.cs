using Moq;
using Sulfur.Constants;
using Sulfur.Models;
using Sulfur.Services.UrlHeaderActions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SulfurXunitTests
{
    public class UrlActionServiceTests
    {
        private readonly IUrlActionService actionService;
        public UrlActionServiceTests()
        {
            var mock = new Mock<UrlActionService>();
            actionService = mock.Object;
        }

        //Just checking there's a match on the received auth token 
        [Fact]
        public void CheckAuthTokenMethodIsSuccessful()
        {    
            Assert.True(actionService.SuccessfulMatchOnHeaderToken(ServiceConstants.AuthTokenPassword));
        }

        //When file has an incorrect format a certain guid should be generated
        [Fact]
        public void GenerateGuidWhenFileIsIncorrectFormat()
        {
            GuidResult resultPayload = actionService.GenerateGuidPayload(false, ServiceConstants.UrlFileDlEnums.FILEINCORRECTFORMAT);

            Assert.True(String.IsNullOrEmpty(resultPayload.Id));
            Assert.False(Boolean.Parse(resultPayload.success));
            Assert.Equal(resultPayload.error, ServiceConstants.FileIncorrectFormat);
        }

        //When url is not valid a certain guid should be generated
        [Fact]
        public void GenerateGuidWhenUrlIsInvalid()
        {
            GuidResult resultPayload = actionService.GenerateGuidPayload(false, ServiceConstants.UrlFileDlEnums.WEBURLISNOTVALID);

            Assert.True(String.IsNullOrEmpty(resultPayload.Id));
            Assert.False(Boolean.Parse(resultPayload.success));
            Assert.Equal(resultPayload.error, ServiceConstants.InvalidWebUrl);
        }

        //When url is valid and torrent file exists
        [Fact]
        public void GenerateGuidWhenUrlIsValidAndTorrentFileExists()
        {
            GuidResult resultPayload = actionService.GenerateGuidPayload(true, ServiceConstants.UrlFileDlEnums.SUCCESS);

            Assert.False(String.IsNullOrEmpty(resultPayload.Id));
            Assert.True(Boolean.Parse(resultPayload.success));
            Assert.True(String.IsNullOrEmpty(resultPayload.error));
        }
    }
}
