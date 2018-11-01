using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLSocketModel
{
    public  class CommandProtocol
    {
        
        public const int LOGIN_CREQ = 1;// 客户端申请登录        
        public const int LOGIN_SRES = 2;// 服务器反馈申请登录给客户端
        
        public const int REG_CREQ = 3;// 客户端申请注册        
        public const int REG_SRES = 4;// 服务器反馈注册给客户端



    }
}
