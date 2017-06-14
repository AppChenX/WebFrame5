using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
namespace CH.Common
{


    /// <summary>
    /// 邮件发送类
    /// </summary>
    public   class EmailSender
    {


        public EmailSender ()
        {

        }
        private string account { get; set; }
        private string pwd { get; set; }
        public EmailSender(string account,string pwd):this()
        {
            this.account = account;
            this.pwd = pwd;
        }

        public void sendMail(string host,string fromEmail,string fromEmailName,string toEmail,string ccEmail ,string title,string content,string fileName)
        {
            //声明一个Mail对象
            MailMessage mymail = new MailMessage();
            //发件人地址
            //如是自己，在此输入自己的邮箱
            mymail.From = new MailAddress(fromEmail, fromEmailName);
            //收件人地址
            mymail.To.Add(new MailAddress(toEmail));
            //邮件主题
            mymail.Subject = title;
            //邮件标题编码h
            mymail.SubjectEncoding = System.Text.Encoding.UTF8;
            //发送邮件的内容
            mymail.Body = content;
            //邮件内容编码
            mymail.BodyEncoding = System.Text.Encoding.UTF8;

            if(!string.IsNullOrEmpty(fileName))
            {
                //添加附件
                Attachment myfiles = new Attachment(fileName);
                mymail.Attachments.Add(myfiles);
            } 
            if(!string.IsNullOrEmpty(ccEmail))
            {
                //抄送到其他邮箱
                mymail.CC.Add(new MailAddress(ccEmail));
            }
          
            //是否是HTML邮件
            mymail.IsBodyHtml = true;
            //邮件优先级
            mymail.Priority = MailPriority.High;
            //创建一个邮件服务器类
            SmtpClient myclient = new SmtpClient();
            myclient.Host = host; //"SMTP.163.com";
            //SMTP服务端口
            myclient.Port = 25;
            //验证登录
            myclient.Credentials = new NetworkCredential(this.account, this.pwd);//"@"输入有效的邮件名, "*"输入有效的密码
            myclient.Send(mymail);
        }
    }



   
}
