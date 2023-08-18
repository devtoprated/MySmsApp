using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.CommonResponseMaker.dto
{
    public class ResponseModel<T> where T : class
    {
        public bool success { get; set; }
        public HttpStatusCode statusCode { get; set; }
        public string message { get; set; }
        public T? entity { get; set; }
        public dynamic? ListingObject { get; set; }
    }
}
