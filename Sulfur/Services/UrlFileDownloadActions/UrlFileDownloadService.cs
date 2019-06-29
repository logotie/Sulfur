using Sulfur.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sulfur.Services.UrlFileDownloadActions
{
    public interface UrlFileDownloadService
    {
        Tuple<bool, ServiceConstants.UrlFileDlEnums> ProcessUrl(String url);
    }
}
