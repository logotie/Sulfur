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

        //Just checking that the string generated from the payload service is not blank or null.
        [Fact]
        public void GenerateNonBlankGuidPayloadString()
        {
            GuidResult resultPayload = actionService.GenerateGuidPayload();

            Assert.False(String.IsNullOrEmpty(resultPayload.Id));
        }

        [Fact]
        public void ValidUrlTest()
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
