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
            if (userCache.IsCreate(accountId)) return null;
            return userCache.GetUserInfo(accountId);
        }

        public void Offline(SocketMessage socketMessage)
        {
            int accountId = accountBiz.GetAccountId(socketMessage.Session);
           // userCache.Offline(accountId);
        }

        public bool Online(SocketMessage socketMessage)
        {
            //int accountId = accountBiz.GetAccountId(socketMessage.Session);
            //if (accountId == -1) return false;
            //if (userCache.IsOnline(accountId)) return false;
            // userCache.Online(socketMessage.Session,accountId);
            return true;
        }
    }
}
