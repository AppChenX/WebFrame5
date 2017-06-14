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
    public class SysRoleServices
    {


        private List<SysRole> Get_ByUserIdNotMaster(string uid)
        {
            using (var db = Linq2DbConnectionManager.Get())
            {
                List<SysRole> rs = null;
                var users = db.Query<SysUserRole>().Where(m => m.UserId == uid).ToList();

                var item_user = users.FirstOrDefault();

                var roles = new CommonData().GetRoleMember(item_user.RoleId, db);
                var s_roles = roles.Select(m => m.RoleId).ToList();

                rs = (from t1 in db.Query<SysRole>() where s_roles.Contains(t1.RoleId) select t1).ToList();

                return rs;
            }
        }

        /// 如果是mysql 树结构sql实现 http://www.cnblogs.com/zf29506564/p/5588153.html
        /// <summary>
        /// 通过用户ID获取该用户ID角色下的所有角色     //注意oracle要更换Sql语句
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<SysRole> Get_ByUserId(string uid)
        {
            List<SysRole> rs = null;
            SysUserServices sv = new SysUserServices();
            string parameterSymbol = string.Empty;
            var user = sv.GetUser_ById(uid);
             
            if (user.IsAdmin.HasValue)
            {
                if ((bool)user.IsAdmin)
                    rs = GetAll();
                else
                {
                    rs=Get_ByUserIdNotMaster(uid);
                }
            }
            else
            {
                rs = Get_ByUserIdNotMaster(uid);

            }
            return rs;
        }
        public List<SysRole> GetAll()
        {
            using (var db = Linq2DbConnectionManager.Get())
            {
                return db.Query<SysRole>().ToList();
            }
        }
        public List<SysRole> GetByRoleId(string rid)
        {
            using (var db = Linq2DbConnectionManager.Get())
            {
                return db.Query<SysRole>().Where(m => m.RoleId == rid).ToList();
            }
        }
        public List<SysRole> GetByUserId(string uid)
        {
            using (var db = Linq2DbConnectionManager.Get())
            {
                var rs = from t1 in db.Query<SysRole>() from t2 in db.Query<SysUserRole>() where t1.RoleId == t2.RoleId && t2.UserId == uid select t1;
                return rs.ToList();
              
            }
        }
        /// <summary>
        /// 保存用户角色
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rid">角色ID</param>
        /// <returns></returns>
        public dynamic SaveUserRole(dynamic data, string rid)
        {
            //选择删除对应rid的全部按钮权限
            using (var db = Linq2DbConnectionManager.Get())
            {
                try
                {
                    List<dynamic> lst = JsonConvert.DeserializeObject<List<dynamic>>(data.ToString());
                    db.Query<SysUserRole>().Delete(m => m.RoleId == rid);
                    //db.dapper.ExecuteBySql<SysUserRole>("DELETE FROM  SYS_USER_ROLE  WHERE  ROLE_ID=@RoleId", new SysUserRole() { RoleId = rid });
                    ///控件一个用户只能一个角色
                    if (lst != null)
                    {
                        //查询用户有没角色
                        lst.ForEach(m => {
                            string uid = m.UserId;
                            //获取用户角色
                            var lst_UserRole = this.GetByUserId(uid);
                            if (lst_UserRole != null)
                            {
                                var item_UserRole = lst_UserRole.FirstOrDefault();
                                if (item_UserRole != null)
                                {
                                    //如果操作的角色和数据库中的角色不一样则不运行添加用户
                                    if (item_UserRole.RoleId != rid)
                                    {
                                        throw new Exception(string.Format("用户{0}已有角色[{1}]", uid, item_UserRole.RoleName));
                                    }
                                }
                            }
                        }
                    );
                        lst.ForEach(m =>
                        {
                            db.Insert<SysUserRole>(new SysUserRole()
                            {
                                UserId = m.UserId,
                                RoleId = rid
                            });
                        }
                        );
                    }
                    return new
                    {
                        status = true,
                        msg = "successful"
                    };
                }
                catch (Exception ex)
                {
                    return new
                    {
                        status = false,
                        msg = ex.Message
                    };
                }
            }
        }
        /// <summary>
        /// 通过用户弹出操作用户角色
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rid"></param>
        /// <returns></returns>
        public dynamic SaveUserRole1(dynamic data)
        {
            //选择删除对应rid的全部按钮权限
            using (var db = Linq2DbConnectionManager.Get())
            {
                try
                {
                    List<dynamic> lst = JsonConvert.DeserializeObject<List<dynamic>>(data.ToString());
                    var userId = lst.FirstOrDefault().UserId;
                    db.Delete<SysUserRole>(new SysUserRole()
                    {
                        UserId = userId
                    });
                    ///控件一个用户只能一个角色
                    if (lst != null)
                    {
                        lst.ForEach(m =>
                        {
                            db.Insert<SysUserRole>(new SysUserRole()
                            {
                                UserId = m.UserId,
                                RoleId = m.RoleId
                            });
                        }
                        );
                    }
                    return new
                    {
                        status = true,
                        msg = "successful"
                    };
                }
                catch (Exception ex)
                {
                    return new
                    {
                        status = false,
                        msg = ex.Message
                    };
                }
            }
        }
        public dynamic SaveRole(dynamic data)
        {
            var json_insert = data["inserted"];
            var json_deleted = data["deleted"];
            var json_updated = data["updated"];
            List<dynamic> lst_insert = null;
            List<dynamic> lst_deleted = null;
            List<dynamic> lst_updated = null;
            if (json_insert != null)
            {
                lst_insert = JsonConvert.DeserializeObject<List<dynamic>>(json_insert.ToString());
            }
            if (json_deleted != null)
            {
                lst_deleted = JsonConvert.DeserializeObject<List<dynamic>>(json_deleted.ToString());
            }
            if (json_updated != null)
            {
                lst_updated = JsonConvert.DeserializeObject<List<dynamic>>(json_updated.ToString());
            }
            using (var db = Linq2DbConnectionManager.Get())
            {
                try
                {
                    if (lst_updated != null)
                        lst_updated.ForEach(m =>
                        {
                            db.Update<SysRole>(new SysRole
                            {
                                RoleId = m.RoleId,
                                RoleName = m.RoleName,
                                RoleDesc = m.RoleDesc
                            });
                        }
);
                    if (lst_insert != null)
                        lst_insert.ForEach(m =>
                        {
                            db.Insert<SysRole>(new SysRole()
                            {
                                RoleId = m.RoleId,
                                RoleName = m.RoleName,
                                RoleDesc = m.RoleDesc
                            });
                        }
 );
                    if (lst_deleted != null)
                        lst_deleted.ForEach(m =>
                        {
                            db.Delete<SysRole>(new SysRole()
                            {
                                RoleId = m.Roleid
                            });
                        }
 );
                    return new
                    {
                        status = true,
                        msg = "successful"
                    };
                }
                catch (Exception ex)
                {
                    return new
                    {
                        status = false,
                        msg = ex.Message
                    };
                }
            }
        }
    }
}