using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurants.Models.Exceptions
{
    public class ClientResponse
    {
        public ClientResponse(bool success,string message, dynamic errors, dynamic result )
        {
            Success = success;
            Message = message;
            Errors = errors;
            Result = result;
        }

        public ClientResponse()
        {

        }

        public bool Success { get; set; }
        public string Message { get; set; }

        public dynamic Errors { get; set; }

        public dynamic Result { get; set; }
    }
}
