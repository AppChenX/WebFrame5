using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqToDB.Mapping;

/* 
Author：Chenl-PC
DateTime：2017-06-10 00:11:32 
*/
/// <summary>
/// 实体类SysUser
/// </summary>
namespace CH.Model
{
    #region  SysUser 

    [Table(Name = "SYS_USER")]
    public class SysUser
    {

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [PrimaryKey]
        [NotNull]
        [Column(Name = "User_Id", CanBeNull = false)]
        public string UserId
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "User_Name")]
        public string UserName
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "User_Pwd")]
        public string UserPwd
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "User_Email")]
        public string UserEmail
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "User_Mobile")]
        public string UserMobile
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Is_Enable")]
        public bool IsEnable
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Is_Admin")]
        public bool? IsAdmin
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Date_LoginLast")]
        public DateTime? DateLoginlast
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Json_Config")]
        public string JsonConfig
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "User_Sex")]
        public string UserSex
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "User_Address")]
        public string UserAddress
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Creater_ID")]
        public string CreaterId
        {
            get;
            set;
        }
    }
    #endregion
}

