using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;
namespace CH.Common
{
    public class RequestUrl
    {
     
       /// <summary>
       /// 获取IP138
       /// </summary>
       public static string[]  GetIp138 { 

            get
            {  
                string[] rs = new string[2];
                string s = GetHttp("http://1212.ip138.com/ic.asp", "http://www.ip138.com/");

                if (!string.IsNullOrEmpty(s))
                {

                    Regex reg = new Regex(@"\[(\S*)\]");
                    string ip = reg.Match(s).Groups[1].Value;


                    reg = new Regex(@"来自：(\S*)");

                    string adress = reg.Match(s).Groups[1].Value;

                    rs[0] = ip;
                    rs[1] = adress;
                }

                return rs;
            }
        }


        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        public static string GetHttp(string url,string host)
        {
            string retString = string.Empty;

            try
            {
            
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.Timeout = 3000;
                request.CookieContainer = new CookieContainer();
                //CookieContainer cookie = request.CookieContainer;//如果用不到Cookie，删去即可  
                //以下是发送的http头，随便加，其中referer挺重要的，有些网站会根据这个来反盗链  
                request.Referer = host;
                request.Accept = "Accept:text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.Headers["Accept-Language"] = "zh-CN,zh;q=0.";
                request.Headers["Accept-Charset"] = "GBK,utf-8;q=0.7,*;q=0.3";
                request.UserAgent = "User-Agent:Mozilla/5.0 (Windows NT 5.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1";
                request.KeepAlive = true;
                //上面的http头看情况而定，但是下面俩必须加  
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "GET"; 
                Encoding encoding = Encoding.GetEncoding("GB2312");//根据网站的编码自定义  
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                //如果http头中接受gzip的话，这里就要判断是否为有压缩，有的话，直接解压缩即可  
                if (response.Headers["Content-Encoding"] != null && response.Headers["Content-Encoding"].ToLower().Contains("gzip"))
                {
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                }
                StreamReader streamReader = new StreamReader(responseStream, encoding);
                retString = streamReader.ReadToEnd();

                streamReader.Close();
                responseStream.Close();
            }
            catch
            {
                retString = string.Empty;
            }

            return retString;
        }


        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string PostHttp(string url, string data)
        {
            string retString = string.Empty;

            try
            {
                  //string postString = "arg1=a&arg2=b";
            //  byte[] postDataStr = Encoding.UTF8.GetBytes("ip=myip");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Timeout = 3000;
            request.CookieContainer = new CookieContainer();
            //CookieContainer cookie = request.CookieContainer;//如果用不到Cookie，删去即可  
            //以下是发送的http头，随便加，其中referer挺重要的，有些网站会根据这个来反盗链  
            request.Referer = url;
            request.Accept = "Accept:text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Headers["Accept-Language"] = "zh-CN,zh;q=0.";
            request.Headers["Accept-Charset"] = "GBK,utf-8;q=0.7,*;q=0.3";
            request.UserAgent = "User-Agent:Mozilla/5.0 (Windows NT 5.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1";
            request.KeepAlive = true;
            //上面的http头看情况而定，但是下面俩必须加  
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            Encoding encoding = Encoding.UTF8;//根据网站的编码自定义  
            byte[] postData = encoding.GetBytes(data);//postDataStr即为发送的数据，格式还是和上次说的一样  
            request.ContentLength = postData.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postData, 0, postData.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            //如果http头中接受gzip的话，这里就要判断是否为有压缩，有的话，直接解压缩即可  
            if (response.Headers["Content-Encoding"] != null && response.Headers["Content-Encoding"].ToLower().Contains("gzip"))
            {
                responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
            }
                StreamReader streamReader = new StreamReader(responseStream, encoding);
                retString = streamReader.ReadToEnd();

                streamReader.Close();
                responseStream.Close(); 
            }
            catch
            {
                retString = string.Empty;
            }

            return retString;
        }
    }
}
