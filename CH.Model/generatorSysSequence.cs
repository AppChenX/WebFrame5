using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqToDB.Mapping;

/* 
Author：Chenl-PC
DateTime：2017-06-14 15:55:17 
*/
/// <summary>
/// 实体类SysSequence
/// </summary>
namespace CH.Model
{
    #region  SysSequence 

    [Table(Name = "SYS_SEQUENCE")]
    public class SysSequence
    {
        #region 注释

        #endregion 注释

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [PrimaryKey]
        [Column(Name = "SEQ_ID")]
        public string SeqId
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "SEQ_NAME")]
        public string SeqName
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "C_FORMAT")]
        public string CFormat
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "C_CURDATE")]
        public string CCurdate
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "N_STEP")]
        public int? NStep
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "C_CURVAL")]
        public string CCurval
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "C_VAL")]
        public string CVal
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "C_PADCHAR")]
        public string CPadchar
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "C_PADLEN")]
        public int? CPadlen
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "C_FORMAT_TYPE")]
        public string CFormatType
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "C_PRECHAR")]
        public string CPrechar
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")] 
        [Column(Name = "C_VERSION")]
        public double CVersion
        {
            get;
            set;
        }
    }
    #endregion
}

