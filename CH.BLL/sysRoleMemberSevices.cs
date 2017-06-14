using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CH.Model;
using DataAccess;
using LinqToDB;
using LinqToDB.Data;
using Newtonsoft.Json;
using CH.Common;

namespace CH.BLL
{
   public class SysRoleMemberSevices
    {


       /// <summary>
       /// 通过角色ID获取所属角色
       /// </summary>
       /// <param name="rid"></param>
       /// <returns></returns>
       public List<SysRoleMemberEx> Get_ByRoleId(string rid)
       {

            string parameterSymbol = string.Empty;
            using (var db = Linq2DbConnectionManager.Get())
            {

                ///注 q角色表中必须有 管理员角色名称，ID为0; 不能删除

                var rs = from t1 in db.Query<SysRoleMember>() from t2 in db.Query<SysRole>() where t2.RoleId == t1.RolePid && t1.RoleId==rid select new SysRoleMemberEx() {
                     RoleId=t1.RoleId, RolePid=t1.RolePid, Creator=t1.Creator, RoleName=t2.RoleName,RoleDesc=t2.RoleDesc
                };

                return rs.ToList();
                //parameterSymbol = (db.DataProvider as LinqToDB.DataProvider.DataProviderBase).ParametersSymbol;
                //return db.Query<SysRoleMemberEx>($"SELECT T.* FROM (SELECT T.*,CASE WHEN T2.ROLE_NAME IS NULL THEN '超级管理员' ELSE T2.ROLE_NAME END AS ROLE_NAME,CASE WHEN T2.ROLE_DESC IS NULL THEN '超级管理员' ELSE T2.ROLE_DESC END ROLE_DESC FROM SYS_ROLE_MEMBER T LEFT JOIN SYS_ROLE T2  ON  T2.ROLE_ID =T.ROLE_PID) T    WHERE  T.ROLE_ID={parameterSymbol}RoleId", new { RoleId = rid }).ToList();
           }
       }

       public dynamic  SaveRoleMember(dynamic data,string uid)
       {

            using (var db = Linq2DbConnectionManager.Get())
            {
               try
               {
                   List<dynamic> lst = JsonConvert.DeserializeObject<List<dynamic>>(data.ToString());

                   //删除数据
                   if (lst != null)
                   {
                       var item = lst.FirstOrDefault();
                        string rid = item.RoleId.ToString();  
                        db.Query<SysRoleMember>().Where(m => m.RoleId == rid).Delete();
                       
                      
                   }

                   //插入数据
                   if (lst != null)
                   {
                       lst.ForEach(m =>
                       {
                           db.Insert<SysRoleMember>(new SysRoleMember() { RoleId=m.RoleId, RolePid=m.RolePid, Creator=uid });
                       });
                   }
                    
                   return new { status = true, msg = "successful" };

               }
               catch (Exception ex)
               { 
                   return new { status = false, msg = ex.Message };
               }
           }
       }
    }
}
