using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace CH.Common.Security
{
   public class Md5
    {
       public static string MD5Encrypt(string input, Encoding encode)
       {
           if (string.IsNullOrEmpty(input))
           {
               return null;
           }
           MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
           byte[] data = md5Hasher.ComputeHash(encode.GetBytes(input));
           StringBuilder sBuilder = new StringBuilder();
           for (int i = 0; i < data.Length; i++)
           {
               sBuilder.Append(data[i].ToString("x2"));
           }
           return sBuilder.ToString();
       }
    }
}
