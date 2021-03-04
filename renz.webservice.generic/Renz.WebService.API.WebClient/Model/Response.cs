using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RivTech.WebService.Generic.WebClient.Model
{
    public class Response
    {
        public string Description { get; set; }
        public Response(string description) 
        {
            this.Description = description;
        }
    }
}
