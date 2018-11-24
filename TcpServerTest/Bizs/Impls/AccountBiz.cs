using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cowboy.Sockets;
using LOLServer.Caches;
using LOLSocketModel;

namespace LOLServer.Bizs
{
    class AccountBiz : IAccountBiz
    {
        IAccountCache accountCache = CacheFactory.accountCache;
        public Result Register(TcpSocketSaeaSession session, string account, string password)
        {
            if (accountCache.IsExistAccount(account))
            {
                return Result.RegAccountExist;
            }
            accountCache.Add(account, password);
            return Result.RegSuccess;
        }

        public int GetAccountId(TcpSocketSaeaSession session)
        {
           return  accountCache.GetUserId(session);
        }

        public Result Login(TcpSocketSaeaSession session, string account, string password)
        {
            if (account == null || password == null) return Result.LoginNameOrPasswordError;
            if (accountCache.IsMatch(account,password)) return Result.LoginNameOrPasswordError;
            if (!accountCache.IsExistAccount(account)) return Result.LoginAccountNotExist;
            if (accountCache.IsOnline(account)) return Result.LoginRepeat;
            accountCache.Online(session, account);
            return Result.LoginSuccess;
        }

        public void Offline(TcpSocketSaeaSession session, string account, string password)
        {
            accountCache.Offline(session);
        }
    }
}
