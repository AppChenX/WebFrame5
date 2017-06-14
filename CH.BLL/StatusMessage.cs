using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CH.BLL
{
    public class StatusMessage
    {
        public string status
        {
            get;
            set;
        }
        public string msg
        {
            get;
            set;
        }
        public StatusMessage()
        {
        }
        public StatusMessage(string status, string msg) : this()
        {
            this.status = status;
            this.msg = msg;
        }
    }
}