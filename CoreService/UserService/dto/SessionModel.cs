using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.UserService.dto
{
    public class SessionModel
    {
        public int currentSession { get; set; }
        public string Response { get; set; }    
    }
}
