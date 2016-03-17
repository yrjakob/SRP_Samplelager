using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class LoginModel : ILoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool inDb { get; set; }
    }
}
