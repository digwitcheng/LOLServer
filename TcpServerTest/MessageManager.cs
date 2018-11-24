using Cowboy.Sockets;
using LOLServer.Logics;
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
        

        private MessageManager()
        {
            reciveMessageQueue = new ConcurrentQueue<SocketMessage>();
            server = new TcpSocketSaeaServer(5555, new SimpleServerMessageDispatcher(reciveMessageQueue));
        }
        public static MessageManager Instance
        {
            get
            {
               return InnerClass.instance;
            }          
        }
        class InnerClass
        {
           public  static readonly MessageManager instance = new MessageManager();
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
                    IReceiveMessage<SocketMessage> receiveHandler = HandlerFactory.CreateHandler(model.Model.Type);
                        receiveHandler.Receive(model,null);
                    
                }
            }
        }

    }
}
