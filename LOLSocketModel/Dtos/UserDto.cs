using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLSocketModel.Dtos
{
    [Serializable]
    public  class UserDto
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

        public UserDto() { }
        public UserDto(int id, string name,int level,int winCount,int loseCount,int runCount,int exp)
        {
            this.Id = id;
            this.Name = name;
            this.Level = level;
            this.Exp = exp;
            this.WinCount = winCount;
            this.LoseCount = loseCount;
            this.RunCount = runCount;
        }
    }
}
