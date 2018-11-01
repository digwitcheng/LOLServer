using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cowboy.Sockets;
using LOLSocketModel;

namespace LOLServer
{
    class SocketMessage
    {
        public TcpSocketSaeaSession Session { get; set; }
        public MessageModel Model { get; set; }
        public SocketMessage(TcpSocketSaeaSession session,MessageModel model)
        {
            this.Session = session;
            this.Model = model;
        }
    }
}
