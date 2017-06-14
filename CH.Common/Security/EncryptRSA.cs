using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CH.Common.Security
{
    public class EncryptRSA
    {

        /// <summary>
        /// 取得密钥对
        /// </summary>
        /// <param name="n">大整数</param>
        /// <param name="e">公钥</param>
        /// <param name="d">密钥</param>
        public void GetKey(out string n, out string e, out string d)
        {
            byte[] pseudoPrime1 = {
                        (byte)0x85, (byte)0x84, (byte)0x64, (byte)0xFD, (byte)0x70, (byte)0x6A,
                        (byte)0x9F, (byte)0xF0, (byte)0x94, (byte)0x0C, (byte)0x3E, (byte)0x2C,
                        (byte)0x74, (byte)0x34, (byte)0x05, (byte)0xC9, (byte)0x55, (byte)0xB3,
                        (byte)0x85, (byte)0x32, (byte)0x98, (byte)0x71, (byte)0xF9, (byte)0x41,
                        (byte)0x21, (byte)0x5F, (byte)0x02, (byte)0x9E, (byte)0xEA, (byte)0x56,
                        (byte)0x8D, (byte)0x8C, (byte)0x44, (byte)0xCC, (byte)0xEE, (byte)0xEE,
                        (byte)0x3D, (byte)0x2C, (byte)0x9D, (byte)0x2C, (byte)0x12, (byte)0x41,
                        (byte)0x1E, (byte)0xF1, (byte)0xC5, (byte)0x32, (byte)0xC3, (byte)0xAA,
                        (byte)0x31, (byte)0x4A, (byte)0x52, (byte)0xD8, (byte)0xE8, (byte)0xAF,
                        (byte)0x42, (byte)0xF4, (byte)0x72, (byte)0xA1, (byte)0x2A, (byte)0x0D,
                        (byte)0x97, (byte)0xB1, (byte)0x31, (byte)0xB3,
                };

            byte[] pseudoPrime2 = {
                        (byte)0x99, (byte)0x98, (byte)0xCA, (byte)0xB8, (byte)0x5E, (byte)0xD7,
                        (byte)0xE5, (byte)0xDC, (byte)0x28, (byte)0x5C, (byte)0x6F, (byte)0x0E,
                        (byte)0x15, (byte)0x09, (byte)0x59, (byte)0x6E, (byte)0x84, (byte)0xF3,
                        (byte)0x81, (byte)0xCD, (byte)0xDE, (byte)0x42, (byte)0xDC, (byte)0x93,
                        (byte)0xC2, (byte)0x7A, (byte)0x62, (byte)0xAC, (byte)0x6C, (byte)0xAF,
                        (byte)0xDE, (byte)0x74, (byte)0xE3, (byte)0xCB, (byte)0x60, (byte)0x20,
                        (byte)0x38, (byte)0x9C, (byte)0x21, (byte)0xC3, (byte)0xDC, (byte)0xC8,
                        (byte)0xA2, (byte)0x4D, (byte)0xC6, (byte)0x2A, (byte)0x35, (byte)0x7F,
                        (byte)0xF3, (byte)0xA9, (byte)0xE8, (byte)0x1D, (byte)0x7B, (byte)0x2C,
                        (byte)0x78, (byte)0xFA, (byte)0xB8, (byte)0x02, (byte)0x55, (byte)0x80,
                        (byte)0x9B, (byte)0xC2, (byte)0xA5, (byte)0xCB,
                };


            BigInteger bi_p = new BigInteger(pseudoPrime1);
            BigInteger bi_q = new BigInteger(pseudoPrime2);
            BigInteger bi_pq = (bi_p - 1) * (bi_q - 1);
            BigInteger bi_n = bi_p * bi_q;
            Random rand = new Random();
            BigInteger bi_e = bi_pq.genCoPrime(512, rand);
            BigInteger bi_d = bi_e.modInverse(bi_pq);
            n = bi_n.ToHexString();
            e = bi_e.ToHexString();
            d = bi_d.ToHexString();
        }

        /**/
        /* 
        功能： 用指定的私钥(n,d)加密指定字符串source  
        */
        private static string EncryptString(string source, BigInteger d, BigInteger n)
        {
            int len = source.Length;
            int len1 = 0;
            int blockLen = 0;
            if ((len % 128) == 0)
                len1 = len / 128;
            else
                len1 = len / 128 + 1;
            string block = "";
            string temp = "";
            for (int i = 0; i < len1; i++)
            {
                if (len >= 128)
                    blockLen = 128;
                else
                    blockLen = len;
                block = source.Substring(i * 128, blockLen);
                byte[] oText = System.Text.Encoding.Default.GetBytes(block);
                BigInteger biText = new BigInteger(oText);
                BigInteger biEnText = biText.modPow(d, n);
                string temp1 = biEnText.ToHexString();
                temp += temp1;
                len -= blockLen;
            }
            return temp;
        }




        /* 
     功能：用指定的公钥(n,e)解密指定字符串 source SS 
     */
        private static string DecryptString(string source, BigInteger e, BigInteger n)
        {
            int len = source.Length;
            int len1 = 0;
            int blockLen = 0;
            if ((len % 256) == 0)
                len1 = len / 256;
            else
                len1 = len / 256 + 1;
            string block = "";
            string temp = "";
            for (int i = 0; i < len1; i++)
            {
                if (len >= 256)
                    blockLen = 256;
                else
                    blockLen = len;
                block = source.Substring(i * 256, blockLen);
                BigInteger biText = new BigInteger(block, 16);
                BigInteger biEnText = biText.modPow(e, n);
                string temp1 = System.Text.Encoding.Default.GetString(biEnText.getBytes());
                temp += temp1;
                len -= blockLen;
            }
            return temp;
        }



        public static string EncryptProcess(string source, string d, string n)
        {

            BigInteger biN = new BigInteger(n, 16);
            BigInteger biD = new BigInteger(d, 16);
            return EncryptString(source, biD, biN);
        }


        public static string DecryptProcess(string source, string e, string n)
        {

            BigInteger biN = new BigInteger(n, 16);
            BigInteger biE = new BigInteger(e, 16);
            return DecryptString(source, biE, biN);
        }



    }

    /*
     * 
     * 
         加密过程和解密过程代码如下所示：
                
                 加密过程,其中d、n是RSACryptoServiceProvider生成的D、Modulus 
              
                private string EncryptProcess(string source, string d, string n) 
                { 
                        byte[] N = Convert.FromBase64String(n); 
                        byte[] D = Convert.FromBase64String(d); 
                        BigInteger biN = new BigInteger(N); 
                        BigInteger biD = new BigInteger(D); 
                        return EncryptString(source, biD, biN); 
                } 
 
                
                 解密过程,其中e、n是RSACryptoServiceProvider生成的Exponent、Modulus 
               
                private string DecryptProcess(string source, string e, string n) 
                { 
                        byte[] N = Convert.FromBase64String(n); 
                        byte[] E = Convert.FromBase64String(e); 
                        BigInteger biN = new BigInteger(N); 
                        BigInteger biE = new BigInteger(E); 
                        return DecryptString(source, biE, biN); 
                } 

 
     * 
     为了生成符合要求的随机RSA密钥，请类似如下操作：

1、在“Number Base”组合框中选择进制为 10 ;
2、单击“Start”按钮，然后随意移动鼠标直到提示信息框出现，以获取一个随机数种子
3、在“KeySize(Bits)”编辑框中输入 32 ；
4、单击“Generate”按钮生成；
5、复制“Prime(P)”编辑框中的内容到“Public Exp.(E)”编辑框；
6、在“Number Base”组合框中选择进制为 16 ;
7、记录下“Prime(P)”编辑框中的十六进制文本内容。
8、再次重复第 2 步；
9、在“KeySize(Bits)”编辑框中输入您所希望的密钥位数，从32到4096，位数越多安全性也高，但运算速度越慢，一般选择1024位足够了；
10、单击“Generate”按钮生成；
11、单击“Test”按钮测试，在“Message to encrypt”编辑框中随意输入一段文本，然后单击“Encrypt”按钮加密，再单击“Decrypt”按钮解密，看解密后的结果是否和所输入的一致，如果一致表示所生成的RSA密钥可用，否则需要重新生成；
12、到此生成完成，“Private Exp.(D)”编辑框中的内容为私钥，第7步所记录的内容为公钥，“Modulus (N)”编辑框中的内容为公共模数，请将上述三段十六进制文本保存起来即可。
     */
}
