using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sulfur.Models
{
    //On receiving a url payload, we return the guid result in this model
    public class GuidResult
    {
        public String Id { get; set; }
        public String success { get; set; }
        public String error { get; set; }
    }
}
