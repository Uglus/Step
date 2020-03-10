using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCinema.Models
{
    class User
    {
        public string UserLogin { get; set; }
        public string UserPass { get; set; }

        public User(string login, string password)
        {
            this.UserLogin = login;
            this.UserPass = password;
        }
    }
}


