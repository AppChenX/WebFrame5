using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqToDB.Mapping;

/* 
Author：Chenl-PC
DateTime：2017-06-10 00:11:44 
*/
/// <summary>
/// 实体类SysUserRole
/// </summary>
namespace CH.Model
{
    #region  SysUserRole 

    [Table(Name = "SYS_USER_ROLE")]
    public class SysUserRole
    {


        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [PrimaryKey]
        [Column(Name = "User_Id", CanBeNull = false)]
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
        [Column(Name = "Role_Id", CanBeNull = false)]
        public string RoleId
        {
            get;
            set;
        }
    }
    #endregion
}

