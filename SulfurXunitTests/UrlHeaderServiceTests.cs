using Moq;
using Sulfur.Constants;
using Sulfur.Services.UrlHeaderActions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SulfurXunitTests
{
    public class UrlHeaderServiceTests
    {
        private readonly IUrlHeaderService headerService;
        public UrlHeaderServiceTests()
        {
            var mock = new Mock<UrlHeaderService>();
            headerService = mock.Object;
        }

        //Just checking there's a match on the received auth token 
        [Fact]
        public void CheckAuthTokenMethodIsSuccessful()
        {    
            Assert.True(headerService.SuccessfulMatchOnHeaderToken(ServiceConstants.AuthTokenPassword));
        }
    }
}
