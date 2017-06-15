using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH.BLL.Sequence
{


    /// <summary>
    /// Guid 序列号
    /// </summary>
    public class SequenceGuid : ISequence
    {
        public object Next(string m = "N")
        {
            if (m == "N")
                return Guid.NewGuid().ToString("N");
            else
               return  GuidTo16String();
        }


        /// <summary>
        /// 根据GUID获取19位的唯一数字序列  
        /// </summary>
        /// <returns></returns>
        private long GenerateIntID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// 生成16位
        /// </summary>
        /// <returns></returns>
        public string GuidTo16String()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
                i *= ((int)b + 1);
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
    }
}
