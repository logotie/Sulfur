using Sulfur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sulfur.Services.UrlHeaderActions
{
    public interface IUrlActionService
    {
        bool SuccessfulMatchOnHeaderToken(String headerToken);
        bool ValidUrl(String url);

        GuidResult GenerateGuidPayload();
    }
}
