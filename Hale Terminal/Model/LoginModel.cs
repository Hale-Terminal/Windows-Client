using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hale_Terminal.Model
{
    public class LoginToken
    {
        public string token { get; set; }
    }

    public class UserLogin
    {
        public string username { get; set; }
        public string password { get; set; }  
    }
}
