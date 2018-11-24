using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLSocketModel
{
    public interface IReceiveMessage<T>
    {
        void Receive(T model,Action<object> action);
    }
}
