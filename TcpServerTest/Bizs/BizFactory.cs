using LOLServer.Bizs.Impls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLServer.Bizs
{
    class BizFactory
    {
        public readonly static IAccountBiz accountBiz;
        public readonly static IUserBiz userBize;

        static BizFactory()
        {
            accountBiz = new AccountBiz();
            userBize = new UserBiz();
        }
    }
}
