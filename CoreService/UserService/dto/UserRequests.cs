using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.UserService.dto
{
    public static class UserRequests
    {
        public enum MenuTypes
        {
            Language = 1,
            Details = 2
        }
        public enum LanguageMenuOptions
        {
            English = 1,
            Hindi = 2,
            Punjabi = 3
        }
    }
}
