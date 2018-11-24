using Cowboy.Sockets;
using LOLServer.Daos.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLServer.Caches
{
    interface IUserCache
    {
        User Create(SocketMessage socketMessage,int accountId);

        bool IsCreate(int accountId);

        User GetUserInfo(int accountId);

        User Online(int accountId);

        void Offline(int accountId);

        //bool IsOnline(int accountId);
    }
}
