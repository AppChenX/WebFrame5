using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqToDB.Mapping;

/* 
Author：Chenl-PC
DateTime：2017-06-10 00:11:28 
*/
/// <summary>
/// 实体类SysSiginLog
/// </summary>
namespace CH.Model
{
    #region  SysSiginLog 

    [Table(Name = "SYS_SIGIN_LOG")]
    public class SysSiginLog
    {

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [PrimaryKey]
        [Column(Name = "LINE_ID", IsIdentity = true)]
        public int LineId
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "LOCAL_IP")]
        public string LocalIp
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "NET_IP")]
        public string NetIp
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "USER_ID")]
        public string UserId
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "USER_NAME")]
        public string UserName
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "LOGIN_ADDRESS")]
        public string LoginAddress
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "LOGIN_DATE")]
        public DateTime? LoginDate
        {
            get;
            set;
        }
    }
    #endregion
}

