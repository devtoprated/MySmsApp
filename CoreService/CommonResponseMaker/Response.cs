using CoreService.CommonResponseMaker.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.CommonResponseMaker
{
    public static class Response<T> where T : class
    {
        public static ResponseModel<T> InternalServerError(string message,T? entity = null)
        {
            return new ResponseModel<T>
            {
                entity = entity,
                statusCode = System.Net.HttpStatusCode.InternalServerError,
                success = true,
                message = message
            };
        }

        public static ResponseModel<T> Success(string messgae, T? entity = null)
        {
            return new ResponseModel<T>
            {
                entity = entity,
                message = messgae,
                statusCode = System.Net.HttpStatusCode.OK,
                success = false
            };
        }
    }
}
