using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLServer.Daos.models
{
    class AccountModel
    {
        public int Id { get;private set; }
        public string Account { get;private set; }
        public string Password { get;private set; }

        public AccountModel(int id,string account,string password)
        {
            this.Id = id;
            this.Account = account;
            this.Password = password;
        }
    }
}
