using HeyRed.Mime;
using Sulfur.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Sulfur.Services.UrlFileDownloadActions
{
    public class UrlFileDownloadService : IUrlFileDownloadService
    {
        //Attempts to download the file at the url
        //Returns a bool and enum signifying if successfull
        //false, WEBURLISNOTVALID - The url is not valid, could be a 500 or 404 and it was unable to download
        //false, FILEINCORRECTFORMAT - The url is valid but the file at the url is not a torrent file
        //true, SUCCESS - Url is valid, file is a torrent file and was able to download.
        public (bool, ServiceConstants.UrlFileDlEnums) ProcessUrl(string url)
        {
            if (ValidUrl(url))
            {
                //Retrieve files as bytes, to be used by mime guesser
                byte[] downloadFile = DownloadFileFromUrl(url);

                if (IsTorrentFile(downloadFile))
                    return CreateAndReturnTuple(true, ServiceConstants.UrlFileDlEnums.Success);
                else
                    return CreateAndReturnTuple(false, ServiceConstants.UrlFileDlEnums.FileIncorrectFormat);
            }

            return CreateAndReturnTuple(false, ServiceConstants.UrlFileDlEnums.WebUrlIsNotValid);
        }

        //Util method to create a tuple.
        private (bool, ServiceConstants.UrlFileDlEnums) CreateAndReturnTuple(bool endResult, ServiceConstants.UrlFileDlEnums resultEnum)
        {
            return(endResult, resultEnum);
        }

        //Returns whether the url is valid
        private bool ValidUrl(string url)
        {
            HttpWebResponse response = null;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD";

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                /* A WebException will be thrown if the status of the response is not `200 OK` */
                return false;
            }
            finally
            {
                // Don't forget to close your response.
                if (response != null)
                {
                    response.Close();
                }
            }

            return true;
        }

        //Checks if the file is a torrent file
        private bool IsTorrentFile(byte[] torrentFileAsBytes)
        {
            //Attempts to guess and return the file type
            string mimeType = MimeGuesser.GuessMimeType(torrentFileAsBytes); //=> image/jpeg

            return mimeType.Equals(ServiceConstants.TorrentMimeType);
        }

        //Attempts to download the file into a byte array
        private byte[] DownloadFileFromUrl(String url)
        {
            byte[] torrentFileAsByteArray;
            using (var webClient = new WebClient())
            {
                torrentFileAsByteArray = webClient.DownloadData(url);
                return torrentFileAsByteArray;
            }
        }
    }
}
