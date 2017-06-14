using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqToDB.Mapping;

/* 
Author：Chenl-PC
DateTime：2017-06-10 00:11:22 
*/
/// <summary>
/// 实体类SysRoleMenu
/// </summary>
namespace CH.Model
{
    #region  SysRoleMenu 

    [Table(Name = "SYS_ROLE_MENU")]
    public class SysRoleMenu
    {
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
        [PrimaryKey]
        [Column(Name = "Role_Id", CanBeNull = false)]
        public string RoleId
        {
            get;
            set;
        }
    }
    #endregion
}

