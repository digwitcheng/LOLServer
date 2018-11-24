using Cowboy.Sockets;
using LOLServer.Daos.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLServer.Bizs
{
    interface IUserBiz
    {
        bool Create(SocketMessage socketMessage);

        User GetUserInfo(SocketMessage socketMessage);

        User Online(SocketMessage socketMessage);

        void Offline(TcpSocketSaeaSession session);
    }
}
