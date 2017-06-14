using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqToDB.Mapping;

/* 
Author：Chenl-PC
DateTime：2017-06-10 00:11:10 
*/
/// <summary>
/// 实体类SysRole
/// </summary>
namespace CH.Model
{
    #region  SysRole 

    [Table(Name = "SYS_ROLE")]
    public class SysRole
    {

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [PrimaryKey]
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

        [Column(Name = "Role_Name")]
        public string RoleName
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]

        [Column(Name = "Role_Desc")]
        public string RoleDesc
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

