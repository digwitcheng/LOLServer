using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLServer.Daos.models
{
    class Account
    {
        public int UserId { get;private set; }
        public string UserAccount { get;private set; }
        public string UserPassword { get;private set; }

        public Account(int id,string account,string password)
        {
            this.UserId = id;
            this.UserAccount = account;
            this.UserPassword = password;
        }
    }
}
