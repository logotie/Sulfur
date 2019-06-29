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

        //Creates an appropriate message and boolean, based on if the url was able to be processed successfully
        public GuidResult GenerateGuidPayload(bool ableToProcess, ServiceConstants.UrlFileDlEnums resultEnum)
        {
            String errormessage = "";

            Guid code = Guid.NewGuid();
            String guid = code.ToString();

            GuidResult responsePayload = new GuidResult();

            switch (resultEnum)
            {
                case ServiceConstants.UrlFileDlEnums.FileIncorrectFormat:
                    errormessage = Sulfur.Resource.FileIncorrectFormat;
                    responsePayload.success = "false";
                    responsePayload.error = errormessage;
                    return responsePayload;

                case ServiceConstants.UrlFileDlEnums.WebUrlIsNotValid:
                    errormessage = Sulfur.Resource.InvalidWebUrl;
                    responsePayload.success = "false";
                    responsePayload.error = errormessage;
                    return responsePayload;
            }

            responsePayload.Id = guid;
            responsePayload.success = "true";
            responsePayload.error = errormessage;
            return responsePayload;
        }


    }
}
