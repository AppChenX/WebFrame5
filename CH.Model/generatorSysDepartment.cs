using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqToDB.Mapping;

/* 
Author：Chenl-PC
DateTime：2017-06-10 00:10:53 
*/
/// <summary>
/// 实体类SysDepartment
/// </summary>
namespace CH.Model
{
    #region  SysDepartment 

    [Table(Name = "SYS_DEPARTMENT")]
    public class SysDepartment
    {
        #region 注释

        #endregion 注释

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [PrimaryKey]
        [Column(Name = "Department_Id", CanBeNull = false)]
        public string DepartmentId
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Department_Name")]
        public string DepartmentName
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Department_PId")]
        public string DepartmentPid
        {
            get;
            set;
        }


        [Column(Name = "Checked", SkipOnInsert = true, SkipOnUpdate = true)]
        public bool Checked
        {
            get;
            set;
        }
    }
    #endregion
}

