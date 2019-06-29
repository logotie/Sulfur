using Sulfur.Constants;
using Sulfur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Sulfur.Services.UrlHeaderActions
{
    public class UrlActionService : IUrlActionService
    {
        //Checks whether the auth header token matches our predefined value
        public bool SuccessfulMatchOnHeaderToken(string headerToken)
        {
            return headerToken.Equals(ServiceConstants.AuthTokenPassword);
        }

        //Create a new Guid code to be sent back as a response.
        //TODO In the future, the UrlPayload will be 
        public GuidResult GenerateGuidPayload()
        {
            Guid code = Guid.NewGuid();
            GuidResult guidCode = new GuidResult();
            guidCode.Id = code.ToString();
            return guidCode;
        }

        //Returns whether the url is valid
        public bool ValidUrl(string url)
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
    }
}
