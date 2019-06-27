using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sulfur.Models
{
    //Model Class for storing the url that will accepted by the Post request
    public class UrlPayload
    {
        //Means the Url field must be present for the model to validate
        [Required]
        //Model binding is not case sensitive
        //https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-2.2
        //Added virtual to allow it to be set/get in the unit tests
        public virtual String Url { get; set; }
    }
}
