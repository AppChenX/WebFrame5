using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqToDB.Mapping;

/* 
Author：Chenl-PC
DateTime：2017-06-10 00:10:57 
*/
/// <summary>
/// 实体类SysMenu
/// </summary>
namespace CH.Model
{
    #region  SysMenu 

    [Table(Name = "SYS_MENU")]
    public class SysMenu
    {
        #region 注释

        #endregion 注释

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [PrimaryKey]
        [Column(Name = "Menu_Id", CanBeNull = false)]
        public string MenuId
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Menu_PID")]
        public string MenuPid
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Menu_Url")]
        public string MenuUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Menu_Name")]
        public string MenuName
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Menu_IconUrl")]
        public string MenuIconurl
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Menu_IconClass")]
        public string MenuIconclass
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Menu_Seq")]
        public int MenuSeq
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Is_Enable")]
        public bool? IsEnable
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Date_Create")]
        public DateTime? DateCreate
        {
            get;
            set;
        }
    }
    #endregion
}

