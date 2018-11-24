using Cowboy.Sockets;
using System.Collections.Generic;
using LOLServer.Daos.models;
using System.Collections.Concurrent;

namespace LOLServer.Caches
{
     class AccountCache : IAccountCache
    {
        //主键
        private int userId = 1;

        //玩家连接对象与账号的绑定
        ConcurrentDictionary<TcpSocketSaeaSession, string> onlineAccount = new ConcurrentDictionary<TcpSocketSaeaSession, string>();
        //账号与自身属性的绑定
        ConcurrentDictionary<string, Account> accountMap = new ConcurrentDictionary<string, Account>();

        public void Add(string account, string password)
        {
            Account model = new Account(userId++,account, password);
            accountMap.AddOrUpdate(account,model, (k, v) => { return v; });
        }

        public int GetUserId(TcpSocketSaeaSession session)
        {
            if (!onlineAccount.ContainsKey(session)) return -1;
            return accountMap[onlineAccount[session]].UserId;
        }

        public bool IsExistAccount(string account)
        {
            return accountMap.ContainsKey(account);
        }

        public bool IsMatch(string account, string password)
        {
            if (!IsExistAccount(account)) return false;
            return accountMap[account].Equals(password);
        }

        public bool IsOnline(string account)
        {
            if (!IsExistAccount(account)) { return false; }
            return onlineAccount.Values.Contains(account);
        }

        public void Offline(TcpSocketSaeaSession session)
        {
            if (onlineAccount.ContainsKey(session))
            {
                string account;
                onlineAccount.TryRemove(session, out account);
            }
        }

        public void Online(TcpSocketSaeaSession session, string account)
        {
            onlineAccount.AddOrUpdate(session, account, (k, v) => { return v; });
        }

       
    }
}