using Microsoft.Extensions.DependencyInjection;
using Moq;
using Sulfur.Models;
using Sulfur.Services.UrlPayloadActions;
using System;
using Xunit;

namespace SulfurXunitTests
{
    public class UrlPayloadServiceTests
    {
        private readonly IUrlPayloadService payloadService;

        public UrlPayloadServiceTests()
        {
            var mock = new Mock<UrlPayloadService>();
            payloadService = mock.Object;
        }


        //Just checking that the string generated from the payload service is not blank or null.
        [Fact]
        public void GenerateNonBlankGuidPayloadString()
        {
            GuidResult resultPayload = payloadService.GenerateGuidPayload();

            Assert.False(String.IsNullOrEmpty(resultPayload.Id));
        }
    }
}
