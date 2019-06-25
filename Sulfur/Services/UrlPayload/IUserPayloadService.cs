using Sulfur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sulfur.Services.UrlPayload
{
    //Methods to be used by the UserPayloadService
    public interface IUserPayloadService
    {
        GuidResult GenerateGuidPayload(string url);
    }
}
