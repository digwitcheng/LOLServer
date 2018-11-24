using Cowboy.Sockets;
using LOLServer.Bizs;
using LOLServer.Daos.models;
using LOLSocketModel;
using LOLSocketModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLServer.Logics.Users
{
    class UserHandler : BaseHandler
    {
        IUserBiz userBiz = BizFactory.userBize;
        public override void Receive(SocketMessage model)
        {
            switch (model.Model.Command)
            {
                case CommandProtocol.CREATE_CREQ:
                    Create(model);
                    break;
                case CommandProtocol.INFO_CREQ:
                    Info(model);
                    break;
                case CommandProtocol.ONLINE_CREQ:
                    Online(model);
                    break;
                default:
                    break;
            }
        }

        private async void Online(SocketMessage model)
        {
            await SendAsync(model, CommandProtocol.ONLINE_SREQ, ConvertToUserDto(userBiz.Online(model)));
        }

        private async void Info(SocketMessage model)
        {
            await SendAsync(model, CommandProtocol.INFO_SREQ, ConvertToUserDto(userBiz.GetUserInfo(model)));
        }

        private async void Create(SocketMessage model)
        {
            string name = (string)model.Model.Message;
            bool result = userBiz.Create(model);
            if (result)
            {
                await SendAsync(model, CommandProtocol.CREATE_SREQ,result);
            }
        }

        private UserDto ConvertToUserDto(User user)
        {
            if (user == null) return null;
            return new UserDto(user.Id, user.Name, user.Level, user.WinCount, user.LoseCount, user.RunCount, user.Exp);
        }

        public  override void Close(TcpSocketSaeaSession session)
        {
            userBiz.Offline(session);
        }
    }
}
