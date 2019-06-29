﻿using System;
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
            INVALIDWEBFORMAT, NOFILEATURL, FILEINCORRECTFORMAT, SUCCESS
        }

        //constants to be used by the UrlActionService when determining a text message
        public static string InvalidWebFormat = "Invalid Web format";
        public static string NoFileAtUrl = "No file at url";
        public static string FileIncorrectFormat = "File at url address is not a torrent";
        public static string Success = "Success";
    }
}