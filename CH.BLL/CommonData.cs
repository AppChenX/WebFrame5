using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CH.Model;
using DataAccess;
namespace CH.BLL
{


    /// <summary>
    /// 通用数据操作类
    /// </summary>
    public class CommonData
    {
        /// <summary>
        /// 递归获取角色所属角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public  List<SysRoleMember> GetRoleMember(string roleId, LinqToDB.Data.DataConnection db)
        {


            var rs = db.Query<SysRoleMember>().Where(M => M.RolePid == roleId).ToList();

            foreach (var item in rs)
            {

                var rs1 = GetRoleMember(item.RoleId, db);

                rs = rs.Union(rs1).ToList();
            }

            return rs;

        }

    }
}
