using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sulfur.Services.UrlHeaderActions
{
    public interface IUrlHeaderService
    {
        bool SuccessfulMatchOnHeaderToken(String headerToken);
    }
}
