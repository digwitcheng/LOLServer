using LOLServer.Exceptions;
using LOLServer.Logics.Users;
using LOLSocketModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLServer.Logics
{
    class HandlerFactory
    {
        public static IReceiveMessage<SocketMessage> CreateHandler(byte type)
        {
            switch (type)
            {
                case TypeProtocol.LOGIN:
                    return new LoginHandler();
                case TypeProtocol.USER:
                    return new UserHandler();
                default:
                    throw new ErrorTypeException();
            }
        }
    }
}
