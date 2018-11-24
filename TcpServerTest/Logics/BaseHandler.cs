using Cowboy.Sockets;
using LOLSocketModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLServer
{
    abstract class BaseHandler: IReceiveMessage<SocketMessage>
    {
        public abstract void Receive(SocketMessage model,Action<object> action=null);
        #region 通过连接对象发送  
        public async Task SendAsync(SocketMessage socketMessage, int command)
        {
            await SendAsync(socketMessage, command, null);
        }
        public async Task SendAsync(SocketMessage socketMessage, int command, object sendMessage)
        {
            await SendAsync(socketMessage, socketMessage.Model.Area, command, sendMessage);
        }
        public async Task SendAsync(SocketMessage socketMessage, int area, int command, object message)
        {
            await SendAsync(socketMessage, socketMessage.Model.Type, area, command, message);
        }
        public async Task SendAsync(SocketMessage socketMessage, byte type, int area, int command, object message)
        {
            MessageModel sendModel = new MessageModel();
            sendModel.Type = type;
            sendModel.Area = area;
            sendModel.Command = command;
            sendModel.Message = message;
            await SendAsync(socketMessage.Session, sendModel);
        }
        public async Task SendAsync(TcpSocketSaeaSession token, byte type, int area, int command, object message)
        {
            await SendAsync(token, new MessageModel(type, area, command, message));
        }
        public async Task SendAsync(TcpSocketSaeaSession token, MessageModel model)
        {
            byte[] value = SerializationUtil.Encode(model);
            await token.SendAsync(value);
        }
        #endregion

        #region 通过ID发送
        public async Task SendAsync(int userId, byte type, int area, int command, object message)
        {

        }
        public async Task SendAsync(int userId, MessageModel model)
        {

        }
        #endregion


    }
}
