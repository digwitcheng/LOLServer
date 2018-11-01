using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LOLSocketModel
{
    public class SerializationUtil
    {
        /// <summary>
        /// 对象序列化
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static byte[]Encode(MessageModel model)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write(model.Type);
            bw.Write(model.Area);
            bw.Write(model.Command);
            if (model.Message != null)
            {
                bf.Serialize(ms, model.Message);
            }
            byte[] result = new byte[ms.Length];
            Buffer.BlockCopy(ms.GetBuffer(), 0, result, 0, (int)ms.Length);
            bw.Close();
            ms.Close();
            return result;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static MessageModel Decode(byte[] data,int offset,int count)
        {
            MemoryStream ms = new MemoryStream(data,offset,count);
            BinaryFormatter bf = new BinaryFormatter();
            MessageModel model = new MessageModel();
            BinaryReader br = new BinaryReader(ms);
            model.Type = br.ReadByte();
            model.Area = br.ReadInt32();
            model.Command = br.ReadInt32();
            if (ms.Position < ms.Length)
            {
                model.Message = bf.Deserialize(ms);
            }
            br.Close();
            ms.Close();
            return model;
        }


    }
}
