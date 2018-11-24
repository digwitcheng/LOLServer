using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cowboy.Sockets;
using LOLServer.Caches;
using LOLServer.Daos.models;

namespace LOLServer.Bizs.Impls
{
    class UserBiz : IUserBiz
    {
        IAccountBiz accountBiz = BizFactory.accountBiz;
        IUserCache userCache = CacheFactory.userCache;
        public bool Create(SocketMessage socketMessage)
        {
            int accountId = accountBiz.GetAccountId(socketMessage.Session);
            if (accountId == -1) return false;
            if (userCache.IsCreate(accountId)) return false;
            userCache.Create(socketMessage,accountId);
            return true;
        }

        public User GetUserInfo(SocketMessage socketMessage)
        {
            int accountId = accountBiz.GetAccountId(socketMessage.Session);
            if (accountId == -1) return null;
            if (!userCache.IsCreate(accountId)) return null;
            return userCache.GetUserInfo(accountId);
        }

        public void Offline(TcpSocketSaeaSession session)
        {
            int accountId = accountBiz.GetAccountId(session);
            userCache.Offline(accountId);
        }

        public User Online(SocketMessage socketMessage)
        {
            int accountId = accountBiz.GetAccountId(socketMessage.Session);
            if (accountId == -1) return null;
            if (!userCache.IsCreate(accountId)) return null;
            return userCache.Online(accountId);          
        }
    }
}
