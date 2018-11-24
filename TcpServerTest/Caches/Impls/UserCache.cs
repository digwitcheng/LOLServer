using Cowboy.Sockets;
using LOLServer.Daos.models;
using System.Collections.Concurrent;

namespace LOLServer.Caches
{
    internal class UserCache : IUserCache
    {
        //<userId,user>
        ConcurrentDictionary<int, User> userIdMap = new ConcurrentDictionary<int, User>();
        //<AccountId,userId>
        ConcurrentDictionary<int, int> accountIdToUserId = new ConcurrentDictionary<int, int>();
      //  ConcurrentDictionary<int, TcpSocketSaeaSession> accountIdToSession = new ConcurrentDictionary<int, TcpSocketSaeaSession>();
       // ConcurrentDictionary<TcpSocketSaeaSession, int> sessionToAccountId = new ConcurrentDictionary<TcpSocketSaeaSession, int>();

        int userId = 1;
        public User Create(SocketMessage socketMessage,int accountId)
        {            
            User user = new User(userId,(string)socketMessage.Model.Message,accountId);
            accountIdToUserId.AddOrUpdate(accountId, userId, (k, v) => { return v; });
            return userIdMap.AddOrUpdate(userId, user, (k, v) => { return v; });           
        }
        public bool IsCreate(int accountId)
        {
            return accountIdToUserId.ContainsKey(accountId);
        }

        public User GetUserInfo(int accountId)
        {
            return userIdMap[accountId];
        }

        public void Offline(int accountId)
        {
            int userId;
            accountIdToUserId.TryRemove(accountId, out userId);
            if (userIdMap.ContainsKey(userId))
            {
                userIdMap.TryRemove(userId, out User a);
            }
        }

        public User Online(int accountId)
        {
            //accountIdToSession.AddOrUpdate(accountId, session, (k, v) => { return v; });
            //sessionToAccountId.AddOrUpdate(session, accountId, (k, v) => { return v; });
            return userIdMap[accountId];

        }

    }
}