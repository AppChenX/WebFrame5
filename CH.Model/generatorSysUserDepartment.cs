using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqToDB.Mapping;

/* 
Author：Chenl-PC
DateTime：2017-06-10 00:11:36 
*/
/// <summary>
/// 实体类SysUserDepartment
/// </summary>
namespace CH.Model
{
    #region  SysUserDepartment 

    [Table(Name = "SYS_USER_DEPARTMENT")]
    public class SysUserDepartment
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [PrimaryKey]
        [Column(Name = "User_id", CanBeNull = false)]
        public string UserId
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [PrimaryKey]
        [Column(Name = "Department_id", CanBeNull = false)]
        public string DepartmentId
        {
            get;
            set;
        }
    }
    #endregion
}

