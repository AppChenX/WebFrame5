using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;
namespace CH.Model
{
    public class SysRoleMemberEx : SysRoleMember
    {
        [Column("ROLE_NAME")]
        public string RoleName
        {
            get;
            set;
        }
        [Column("Role_Desc")]
        public string RoleDesc
        {
            get;
            set;
        }
    }
}
