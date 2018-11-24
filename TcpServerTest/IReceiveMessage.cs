using Cowboy.Sockets;
using LOLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLSocketModel
{
     interface IMessageHandler<T>
    {
        void Receive(T message);
        void Close(TcpSocketSaeaSession session);
    }
}
