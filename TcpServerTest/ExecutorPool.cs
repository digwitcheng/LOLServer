using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLServer
{
    class ExecutorPool
    {
        private readonly object exeLock = new object();
        private static ExecutorPool instance = new ExecutorPool();
        public static ExecutorPool Instance
        {
            get { return instance; }
        }

        public void Execute(Action action)
        {
            lock (exeLock)
            {
                action();
            }
        }

    }
}
