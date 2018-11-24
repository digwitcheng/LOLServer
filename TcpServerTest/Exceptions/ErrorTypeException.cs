using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLServer.Exceptions
{
    class ErrorTypeException : Exception
    {
        public ErrorTypeException()
        {
            this.Error = "错误的模块类型";
        }
        public ErrorTypeException(string error):base(error)
        {
            this.Error = error;
        }
        public ErrorTypeException(string error,Exception exception) : base(error,exception)
        {
            this.Error = error;
        }
        public string Error { get; set; }
    }
}
