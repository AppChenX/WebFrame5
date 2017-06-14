using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CH.Model;
using DataAccess;
using LinqToDB;
using LinqToDB.Data;
using Newtonsoft.Json; 
namespace CH.BLL
{
    public class SysActionServices
    {
        /// <summary>
        /// 查询菜单中的按钮
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public List<SysAction> GetBy_MenuId(string mid)
        {
            using (var db = Linq2DbConnectionManager.Get())
            {
                return db.Query<SysAction>().Where(m => m.MenuId == mid).ToList();
            }
        }
        /// <summary>
        /// 保存按钮角色
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rid"></param>
        /// <returns></returns>
        public dynamic SaveActionRole(dynamic data, string rid)
        {
            //选择删除对应rid的全部按钮权限
            using (var db = Linq2DbConnectionManager.Get())
            {
                try
                {
                    List<dynamic> lst = JsonConvert.DeserializeObject<List<dynamic>>(data.ToString());
                    //db.Delete<SysRoleAction>(new SysRoleAction()
                    //{
                    //    RoleId = rid
                    //});
                    db.Query<SysRoleAction>().Where(m => m.RoleId == rid).Delete();
                    if (lst != null)
                    {
                        lst.ForEach(m =>
                        {
                            db.Insert<SysRoleAction>(new SysRoleAction()
                            {
                                ActionId = m.id,
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
        /// 编辑保存按钮
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        public dynamic SaveAction(dynamic data, string mid)
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
                            db.Update<SysAction>(new SysAction
                            {
                                MenuId = mid,
                                ActionName = m.ActionName,
                                ActionUrl = m.ActionUrl,
                                ActionIconclass = m.ActionIconclass,
                                ActionIconurl = m.ActionIconurl,
                                ActionBid = m.ActionBid,
                                ActionId = m.ActionId
                            });
                        }
);
                    if (lst_insert != null)
                        lst_insert.ForEach(m =>
                        {
                            db.Insert<SysAction>(new SysAction
                            {
                                MenuId = mid,
                                ActionName = m.ActionName,
                                ActionUrl = m.ActionUrl,
                                ActionIconclass = m.ActionIconclass,
                                ActionIconurl = m.ActionIconurl,
                                ActionBid = m.ActionBid,
                                ActionId = m.ActionId
                            });
                        }
);
                    if (lst_deleted != null)
                        lst_deleted.ForEach(m =>
                        {
                            db.Delete<SysAction>(new SysAction()
                            {
                                ActionId = m.ActionId
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