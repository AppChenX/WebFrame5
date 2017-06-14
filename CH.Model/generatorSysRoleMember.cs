using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqToDB.Mapping;

/* 
Author：Chenl-PC
DateTime：2017-06-10 00:11:18 
*/
/// <summary>
/// 实体类SysRoleMember
/// </summary>
namespace CH.Model
{
    #region  SysRoleMember 

    [Table(Name = "SYS_ROLE_MEMBER")]
    public class SysRoleMember
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Role_Id", CanBeNull = false)]
        public string RoleId
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Role_PID", CanBeNull = false)]
        public string RolePid
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Creator")]
        public string Creator
        {
            get;
            set;
        }
    }
    #endregion
}

