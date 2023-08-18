using CoreService.UserService.dto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.UserService.ResponseMaker
{
    public interface ISmsReplyService
    {
        Task<SessionModel> GetReply(Dictionary<string, StringValues> Data,int menuType);
    }
}
