using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cowboy.Sockets;

namespace LOLServer.Caches
{
    interface IAccountCache
    {
        bool IsExistAccount(string account);

        bool IsMatch(string account, string password);

        bool IsOnline(string account);

        /// <summary>
        /// 当前连接对象对应的账号Id
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        int GetUserId(TcpSocketSaeaSession session);


        void Online(TcpSocketSaeaSession session, string account);

        void Offline(TcpSocketSaeaSession session);

        void Add(string account, string password);

    }
}
