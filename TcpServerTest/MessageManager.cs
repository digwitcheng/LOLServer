using Cowboy.Sockets;
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
    class MessageManager
    {
        private TcpSocketSaeaServer server;
        private ConcurrentQueue<SocketMessage> reciveMessageQueue;
        private IReceiveMessage loginReceive;
        

        private MessageManager()
        {
            reciveMessageQueue = new ConcurrentQueue<SocketMessage>();
            server = new TcpSocketSaeaServer(5555, new SimpleServerMessageDispatcher(reciveMessageQueue));
            loginReceive = new LoginHandler();
        }

        private static MessageManager instance;
        private static readonly object instanceLock = new object();
        public static MessageManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (instanceLock)
                    {
                        if (instance == null)
                        {
                            instance = new MessageManager();
                        }
                    }
                }
                return instance;
            }
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
                            loginReceive.Receive(model);
                            break;
                        default:
                            break;

                    }
                }
            }
        }

    }
}
