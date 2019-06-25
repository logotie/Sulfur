using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sulfur.Models;

namespace Sulfur.Services.UrlPayload
{
    public class UrlPayloadService : IUrlPayloadService
    {
        //Create a new Guid code to be sent back as a response.
        GuidResult IUrlPayloadService.GenerateGuidPayload(string url)
        {
            Guid code = Guid.NewGuid();
            GuidResult guidCode = new GuidResult();
            guidCode.Id = code.ToString();
            return guidCode;
        }
    }
}
