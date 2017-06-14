using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqToDB.Mapping;

/* 
Author：Chenl-PC
DateTime：2017-06-10 00:15:44 
*/
/// <summary>
/// 实体类SysSetting
/// </summary>
namespace CH.Model
{
    #region  SysSetting 

    [Table(Name = "SYS_SETTING")]
    public class SysSetting
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [PrimaryKey]
        [Column(Name = "Id")]
        public int Id
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Code")]
        public string Code
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Value")]
        public string Value
        {
            get;
            set;
        }
    }
    #endregion
}

