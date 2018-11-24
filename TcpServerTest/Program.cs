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
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               MessageManager.Instance.Start();
                while (true)
                {                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("服务器启动失败："+e.ToString());
            }
           
        }
    }
   

}
