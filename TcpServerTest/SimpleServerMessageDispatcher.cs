using Cowboy.Sockets;
using LOLSocketModel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLServer
{
    class SimpleServerMessageDispatcher : ITcpSocketSaeaServerMessageDispatcher
    {
        private ConcurrentQueue<SocketMessage> reciveMessageQueue;
        public SimpleServerMessageDispatcher(ConcurrentQueue<SocketMessage> messageQueue)
        {
            this.reciveMessageQueue = messageQueue;
        }

        public async Task OnSessionClosed(TcpSocketSaeaSession session)
        {
            Console.WriteLine("closed:" + session.RemoteEndPoint);
            await Task.CompletedTask;
        }

        public async Task OnSessionDataReceived(TcpSocketSaeaSession session, byte[] data, int offset, int count)
        {
            MessageModel sm = SerializationUtil.Decode(data, offset, count);
            if (sm != null)
            {
                reciveMessageQueue.Enqueue(new SocketMessage(session,sm));
            }
            Console.WriteLine(count);
            await Task.CompletedTask;
        }

        public async Task OnSessionStarted(TcpSocketSaeaSession session)
        {
            Console.WriteLine("connected:" + session.RemoteEndPoint);
            await Task.CompletedTask;
        }
    }

}
