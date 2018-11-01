using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLSocketModel
{
    [Serializable]
    public class MessageModel
    {
        /// <summary>
        /// 一级协议, 用于区分所属模块
        /// </summary>
        public byte Type { get; set; }
        /// <summary>
        /// 二级, 用于区分主模块下的分模块
        /// </summary>
        public int Area { get; set; }
        /// <summary>
        /// 三级协议, 用于区分当前处理逻辑功能
        /// </summary>
        public int Command { get; set; }
        /// <summary>
        /// 消息体, 当前需要处理的主体数据
        /// </summary>
        public object Message { get; set; }

        public MessageModel() { }
        public MessageModel(byte Type, int Area, int Command, object Message)
        {
            this.Type = Type;
            this.Area = Area;
            this.Command = Command;
            this.Message = Message;
        }


    }
}
