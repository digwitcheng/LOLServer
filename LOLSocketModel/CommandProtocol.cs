using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLSocketModel
{
    public  class CommandProtocol
    {
        //login
        public const int LOGIN_CREQ = 11;// 客户端申请登录        
        public const int LOGIN_SRES = 12;// 服务器反馈申请登录给客户端
        public const int REG_CREQ = 13;// 客户端申请注册        
        public const int REG_SRES = 14;// 服务器反馈注册给客户端

        //user
        public const int INFO_CREQ= 21;//获取自身数据
        public const int INFO_SREQ= 22;//返回自身数据
        public const int CREATE_CREQ= 23;//申请创建角色
        public const int CREATE_SREQ= 24;//返回创建结果
        public const int ONLINE_CREQ = 25;//申请登录角色
        public const int ONLINE_SREQ = 26;//返回登录结果


    }
}
