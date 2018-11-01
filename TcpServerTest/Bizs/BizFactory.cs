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

        static BizFactory()
        {
            accountBiz = new AccountBiz();
        }
    }
}
