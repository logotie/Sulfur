using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sulfur.Services.UrlTorrentDownloadActions
{
    public interface IUrlTorrentService
    {
        bool DoesTorrentContainAudioFiles(String url);
    }
}
