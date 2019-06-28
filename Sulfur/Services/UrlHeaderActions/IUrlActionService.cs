using Sulfur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sulfur.Services.UrlHeaderActions
{
    public interface IUrlAactionService
    {
        bool SuccessfulMatchOnHeaderToken(String headerToken);

        GuidResult GenerateGuidPayload();
    }
}
