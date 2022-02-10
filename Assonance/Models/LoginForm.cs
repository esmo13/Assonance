using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assonance.Models
{
    public class LoginForm
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public LoginForm()
        {
        }

        public LoginForm(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
