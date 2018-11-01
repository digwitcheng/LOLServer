using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLSocketModel
{
    public enum Result:byte
    {
        //注册结果   0 成功，1 账号已存在 2 账号不合法，3 密码不合法
        RegSuccess = 10,
        RegAccountExist=11,
        RegNameIllegal=12,
        RegPasswordIllegal=13,

        //登录结果 0 成功，1 账号不存在, 2 账号或密码错误, 3 账号已登录
        LoginSuccess = 20,
        LoginAccountNotExist = 21,
        LoginNameOrPasswordError = 22,
        LoginRepeat = 23
    }
}
