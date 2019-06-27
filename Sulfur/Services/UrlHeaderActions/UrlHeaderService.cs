using Sulfur.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sulfur.Services.UrlHeaderActions
{
    public class UrlHeaderService : IUrlHeaderService
    {
        //Checks whether the auth header token matches our predefined value
        public bool SuccessfulMatchOnHeaderToken(string headerToken)
        {
            return String.Equals(headerToken, ServiceConstants.AuthTokenPassword);
        }
    }
}
