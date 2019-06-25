using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sulfur.Models
{
    //Model Class for storing the url that will accepted by the Post request
    public class UrlPayload
    {
        //Model binding is not case sensitive
        //https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-2.2
        public String Url { get; set; }
    }
}
