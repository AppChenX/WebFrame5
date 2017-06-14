using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqToDB.Mapping;

/* 
Author：Chenl-PC
DateTime：2017-06-10 00:15:14 
*/
/// <summary>
/// 实体类SysAction
/// </summary>
namespace CH.Model
{
    #region  SysAction 

    [Table(Name = "SYS_ACTION")]
    public class SysAction
    {


        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [PrimaryKey]
        [Column(Name = "Action_Id", CanBeNull = false)]
        public string ActionId
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Menu_Id")]
        public string MenuId
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Action_Name")]
        public string ActionName
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Action_Url")]
        public string ActionUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Action_IconClass")]
        public string ActionIconclass
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Action_IconUrl")]
        public string ActionIconurl
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Action_BId")]
        public string ActionBid
        {
            get;
            set;
        }
    }
    #endregion
}

