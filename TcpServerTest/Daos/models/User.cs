using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLServer.Daos.models
{
    class User
    {
        //主键
        public int Id { get; set; }
        //昵称
        public string Name { get; set; }
        //等级
        public int Level { get; set; }
        //经验
        public int Exp { get; set; }
        //胜利场数
        public int WinCount { get; set; }
        //失败场数
        public int LoseCount { get; set; }
        //逃跑场数
        public int RunCount { get; set; }
        //角色所属的账号ID
        public int AccountId { get; set; }

        public User(int id,string name,int accountId)
        {
            this.AccountId = accountId;
            this.Id = id;
            this.Name = name;
            this.Level = 1;
            this.Exp = 0;
            this.WinCount = 0;
            this.LoseCount = 0;
            this.RunCount = 0;
        }
    }
}
