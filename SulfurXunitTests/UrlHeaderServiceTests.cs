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
            var mock = new Mock<UrlHeaderService>();
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
    }
}
