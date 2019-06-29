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
        //Attempts to 
        public Tuple<bool, ServiceConstants.UrlFileDlEnums> ProcessUrl(string url)
        {
            if (ValidUrl(url))
            {

            }
            else
            {
                return Tuple.Create<bool, ServiceConstants.UrlFileDlEnums>(false, ServiceConstants.UrlFileDlEnums.WEBURLISNOTVALID);
            }

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

        private bool IsTorrentFile(String url)
        {

        }
    }
}
