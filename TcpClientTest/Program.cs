using Cowboy.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpSocketSaeaClient client = new TcpSocketSaeaClient("127.0.0.1",5555, new SimpleSaeaClientMessageDispatcher());
            try
            {
                client.Connect().Wait();
                //  Task.Run(async () => { await client.Connect(); });
                while (true)
                {
                    string msg = Console.ReadLine();
                    Task.Run(async () => await client.SendAsync(Encoding.Default.GetBytes(msg)));
                }
            }catch(Exception e)
            {
               // Logger.Get<Program>().Error(ex.Message, ex);
            }
            Console.ReadKey();
        }
    }

    class SimpleSaeaClientMessageDispatcher : ITcpSocketSaeaClientMessageDispatcher
    {
        public async Task OnServerConnected(TcpSocketSaeaClient client)
        {
            Console.WriteLine("connected to server:" + client.RemoteEndPoint);
            
        }

        public async Task OnServerDataReceived(TcpSocketSaeaClient client, byte[] data, int offset, int count)
        {
            string msg = Encoding.Default.GetString(data, offset, count);
            Console.WriteLine(msg);
        }

        public async Task OnServerDisconnected(TcpSocketSaeaClient client)
        {
            Console.WriteLine("closed:" + client.RemoteEndPoint);
        }
    }
}
