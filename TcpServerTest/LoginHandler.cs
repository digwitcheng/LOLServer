using System;
using System.Threading.Tasks;
using LOLServer.Bizs;
using LOLSocketModel;
using LOLSocketModel.Dtos;

namespace LOLServer
{
     class LoginHandler :BaseHandler, IReceiveMessage
    {
        IAccountBiz accountBiz = BizFactory.accountBiz;

        public void Receive(SocketMessage message)
        {
            switch (message.Model.Command)
            {
                case CommandProtocol.LOGIN_CREQ:
                    Login(message);
                    break;
                case CommandProtocol.REG_CREQ:
                    Reg(message);
                    break;
            }
        }

        private async void Reg(SocketMessage message)
        {
            AccountInfoDto accountInfo = (AccountInfoDto)message.Model.Message;
            Result result = accountBiz.Register(message.Session, accountInfo.Account, accountInfo.Password);
            await SendAsync(message, CommandProtocol.REG_SRES, (byte)result);
        }

        private async void Login(SocketMessage message)
        {
            AccountInfoDto accountInfo = (AccountInfoDto)message.Model.Message;
            Result result= accountBiz.Login(message.Session, accountInfo.Account, accountInfo.Password);
           await  SendAsync(message, CommandProtocol.LOGIN_SRES, (byte)result);

        }
       
    }
}