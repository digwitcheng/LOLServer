using Cowboy.Sockets;
using LOLServer.Logics;
using LOLServer.Logics.Users;
using LOLSocketModel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LOLServer
{
    class MessageManager: ITcpSocketSaeaServerMessageDispatcher
    {
        private TcpSocketSaeaServer server;
        private ConcurrentQueue<SocketMessage> reciveMessageQueue;
        IMessageHandler<SocketMessage> loginHandler;
        IMessageHandler<SocketMessage> userHandler;

        private MessageManager()
        {
            reciveMessageQueue = new ConcurrentQueue<SocketMessage>();
            server = new TcpSocketSaeaServer(5555,this);
            loginHandler = new LoginHandler();
            userHandler = new UserHandler();
        }
        public static MessageManager Instance
        {
            get { return InnerClass.MessageManagerInstance; }
        }
        private class InnerClass
        {
            public static MessageManager MessageManagerInstance = new MessageManager();
        }

        public void Start()
        {
            server.Listen();
            Console.WriteLine("服务器已启动");
            Task.Factory.StartNew (()=> ReceiveMessageHandler());
        }

        void ReceiveMessageHandler()
        {
            while (true)
            {
                if (reciveMessageQueue.IsEmpty)
                {
                    Thread.Sleep(ConstDefine.HANDLER_RECEIVE_MESSAGE_TIME);
                }
                else
                {
                    SocketMessage model;
                    reciveMessageQueue.TryDequeue(out model);
                    switch (model.Model.Type)
                    {
                        case TypeProtocol.LOGIN:
                            loginHandler.Receive(model);
                            break;
                        case TypeProtocol.USER:
                            userHandler.Receive(model);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public async Task OnSessionClosed(TcpSocketSaeaSession session)
        {
            Console.WriteLine(session.RemoteEndPoint+"断开");
            userHandler.Close(session);
            loginHandler.Close(session);
            await Task.CompletedTask;
        }

        public async Task OnSessionDataReceived(TcpSocketSaeaSession session, byte[] data, int offset, int count)
        {
            MessageModel sm = SerializationUtil.Decode(data, offset, count);
            if (sm != null)
            {
                reciveMessageQueue.Enqueue(new SocketMessage(session, sm));
            }
            await Task.CompletedTask;
        }

        public async Task OnSessionStarted(TcpSocketSaeaSession session)
        {
            Console.WriteLine("connected:" + session.RemoteEndPoint);
            await Task.CompletedTask;
        }

    }
}
