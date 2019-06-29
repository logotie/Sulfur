using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sulfur.Constants
{
    public static class ServiceConstants
    {
        //Constants to be used for the services

        //The auth password for the header token
        public static string AuthTokenPassword = "TEST";

        //enums to be used by the UrlFileDownload service
        public enum UrlFileDlEnums
        {
            WEBURLISNOTVALID, FILEINCORRECTFORMAT, SUCCESS
        }

        //constants to be used by the UrlActionService when determining a text message
        public static string InvalidWebUrl = "Web url is not valid";
        public static string FileIncorrectFormat = "File at url address is not a torrent file";
        public static string Success = "Success";

        //used by the UrlFileDownload service when guessing a mime type
        public static string TorrentMimeType = "application/x-bittorrent";
    }
}
