using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqToDB.Mapping;

/* 
Author：Chenl-PC
DateTime：2017-06-10 00:11:14 
*/
/// <summary>
/// 实体类SysRoleAction
/// </summary>
namespace CH.Model
{
    #region  SysRoleAction 

    [Table(Name = "SYS_ROLE_ACTION")]
    public class SysRoleAction
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
        [PrimaryKey]
        [Column(Name = "Action_Id", CanBeNull = false)]
        public string ActionId
        {
            get;
            set;
        }
    }
    #endregion
}

