using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cowboy.Sockets;
using LOLSocketModel;

namespace LOLServer.Bizs
{
    interface IAccountBiz
    {
        /// <summary>
        /// 创建账号
        /// </summary>
        /// <param name="session"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns>10 成功，11 账号已存在 12 账号不合法，13 密码不合法</returns>
        Result Register(TcpSocketSaeaSession session, string account,string password);

        /// <summary>
        /// 登录账号
        /// </summary>
        /// <param name="session"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns>20 成功，21 账号不存在, 22 账号或密码错误, 23 账号已登录</returns>
        Result Login(TcpSocketSaeaSession session, string account, string password);

        /// <summary>
        /// 下线
        /// </summary>
        /// <param name="session"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        void Offline(TcpSocketSaeaSession session, string account, string password);

        int GetUserId(TcpSocketSaeaSession session);
    }
}
