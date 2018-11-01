using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLServer
{
    interface IReceiveMessage
    {
        void Receive(SocketMessage message);
    }
}
