using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CH.Common.Utility
{


    /// <summary>
    /// RazorEnigine字符串帮助类
    /// </summary>
    public static  class RazorHelper
    {


        /// <summary>
        /// 转换为Pascal编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToPascal(this string str)
            {
                var separator = new[] { '_', '-' };

                StringBuilder sb = new StringBuilder();
                string[] parts = str.Split(separator);
                foreach (string part in parts)
                {
                    if (part.Length > 0)
                    {
                        sb.Append(Char.ToUpper(part[0]));
                        if (part.Length > 1) sb.Append(part.Substring(1).ToLower());
                    }
                }

                return sb.ToString();
            }
       
    }
}
