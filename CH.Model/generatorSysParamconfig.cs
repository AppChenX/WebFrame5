using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqToDB.Mapping;

/* 
Author：Chenl-PC
DateTime：2017-06-10 00:11:01 
*/
/// <summary>
/// 实体类SysParamconfig
/// </summary>
namespace CH.Model
{
    #region  SysParamconfig 

    [Table(Name = "SYS_PARAMCONFIG")]
    public class SysParamconfig
    {


        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "ID", CanBeNull = false)]
        public int Id
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "SPNAME")]
        public string Spname
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "ArgName")]
        public string Argname
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "DataType")]
        public string Datatype
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Direction")]
        public string Direction
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Seq")]
        public int? Seq
        {
            get;
            set;
        }
    }
    #endregion
}

