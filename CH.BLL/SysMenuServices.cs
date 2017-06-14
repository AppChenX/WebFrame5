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
    public class SysMenuServices
    {
        public List<SysMenu> GetAll()
        {
            using (var db = Linq2DbConnectionManager.Get())
            {
                return db.Query<SysMenu>().OrderBy(m => m.MenuSeq).ToList();
            }
        }
        /// <summary>
        /// 保存角色菜单
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rid"></param>
        /// <returns></returns>
        public dynamic SaveMenuRole(dynamic data, string rid)
        {
            using (var db = Linq2DbConnectionManager.Get())
            {
                try
                {
                    List<dynamic> lst = JsonConvert.DeserializeObject<List<dynamic>>(data.ToString());
                    db.Query<SysRoleMenu>().Delete(m => m.RoleId == rid);
                    if (lst != null)
                    {
                        lst.ForEach(m =>
                        {
                            db.Insert<SysRoleMenu>(new SysRoleMenu()
                            {
                                MenuId = m.id,
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
        /// 获取菜单按钮权限
        /// </summary>
        /// <param name="uid">操作用户</param>
        /// <param name="rid">对应的角色</param>
        /// <returns></returns>
        public List<SysMenuEx2> GetMenuAndAction(string uid, string rid)
        {
            string sql = string.Empty;

            string parameterSymbol = string.Empty;
            //
            ///如果没有相应权限的菜单则不出现勾选，没有权限不选中，0 false

            using (var db = Linq2DbConnectionManager.Get())
            {
                //parameterSymbol = (db.DataProvider as LinqToDB.DataProvider.DataProviderBase).ParametersSymbol;
                //sql = $"SELECT  T.MENU_ID ,T.MENU_PID,T.MENU_NAME,T.MENU_ICONURL,T.MENU_ICONCLASS ,0 AS CHECKED ,1 AS NCHECK FROM 	 	SYS_MENU T UNION SELECT T.ACTION_ID MENU_ID, T.MENU_ID AS  MENU_PID, T.ACTION_NAME AS MENU_NAME, T.ACTION_ICONURL AS MENU_ICONURL, T.ACTION_ICONCLASS AS   MENU_ICONCLASS , CASE WHEN(SELECT 1 FROM SYS_ROLE_ACTION T1 WHERE T1.ACTION_ID = T.ACTION_ID AND T1.ROLE_ID = {parameterSymbol}rid)  IS NULL THEN 0 ELSE 1 END AS    CHECKED   , CASE WHEN(SELECT 1 FROM SYS_ROLE_MENU TM WHERE TM.MENU_ID = T.MENU_ID AND TM.ROLE_ID = {parameterSymbol}rid) IS NULL THEN 1 ELSE 0 END AS NCHECK FROM SYS_ACTION T";
                //var rs = db.Query<SysMenuEx2>(sql, new { rid = rid, uid = uid }).ToList();

                //              SELECT T.ACTION_ID MENU_ID,
                //     T.MENU_ID AS MENU_PID,
                //     T.ACTION_NAME AS MENU_NAME,
                //     T.ACTION_ICONURL AS MENU_ICONURL,
                //     T.ACTION_ICONCLASS AS MENU_ICONCLASS,
                //     T1.ACTION_ID,
                //     T2.MENU_ID
                //FROM SYS_ACTION T
                //LEFT JOIN SYS_ROLE_ACTION T1
                //  ON T.ACTION_ID = T1.ACTION_ID
                // AND T1.ROLE_ID = 'R001'
                //LEFT JOIN SYS_ROLE_MENU T2
                //  ON T.MENU_ID = T2.MENU_ID
                // AND T2.ROLE_ID = 'R001'


                var rs = (from t1 in db.Query<SysMenu>()
                          select new SysMenuEx2()
                          {
                              Checked = false,
                              NCheck = true,
                              MenuId = t1.MenuId,
                              MenuPid = t1.MenuPid,
                              MenuName = t1.MenuName,
                              MenuIconurl = t1.MenuIconurl,
                              MenuIconclass = t1.MenuIconclass
                          }).Concat(from t1 in db.Query<SysAction>()
                                    join t2 in db.Query<SysRoleAction>() on new { a = t1.ActionId, b = rid } equals new { a = t2.ActionId, b = t2.RoleId } into t4
                                    from t2 in t4.DefaultIfEmpty()
                                    join t3 in db.Query<SysRoleMenu>() on new { a = t1.MenuId, b = rid } equals new { a = t3.MenuId, b = t3.RoleId } into t5
                                    from t3 in t5.DefaultIfEmpty()
                                    select new SysMenuEx2()
                                    {
                                        Checked = t2.ActionId==null?false:true,
                                        NCheck = t3.MenuId==null?true:false,
                                        MenuId = t1.ActionId,
                                        MenuPid = t1.MenuId,
                                        MenuName = t1.ActionName,
                                        MenuIconurl = t1.ActionIconurl,
                                        MenuIconclass = t1.ActionIconclass

                                    });

                return rs.ToList();
            }
        }


        /// <summary>
        /// 通过用户ID获取菜单不包包括超级管理员
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        private List<SysMenu> GetMenu_ByUserId(string uid)
        {
            List<SysMenu> rs = null;
            using (var db = Linq2DbConnectionManager.Get())
            {
                rs = (from t1 in db.Query<SysRoleMenu>() from t2 in db.Query<SysUserRole>() from t3 in db.Query<SysMenu>() where t1.RoleId == t2.RoleId && t3.MenuId == t1.MenuId && t2.UserId == uid select t3).ToList();
                return rs;
            }
        }
        /// <summary>
        /// 通过用户ID获取菜单
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<SysMenu> GetMenuByUid(string uid)
        {
            //如果是超级管理员
            SysUserServices sv = new SysUserServices();
            List<SysMenu> rs = null;
            var user = sv.GetUser_ById(uid);
            if (user.IsAdmin.HasValue)
            {
                if ((bool)user.IsAdmin)
                {
                    rs = GetAll();
                }
                else
                {
                    rs = GetMenu_ByUserId(uid);
                }
            }
            else
            {
                rs = GetMenu_ByUserId(uid);
            }
            //不是超级管理员 else 

            return rs;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid">登录ID</param>
        /// <param name="rid">所选择的用户角色</param>
        /// <returns></returns>
        public List<SysMenuEx> GetMenuExByLoginUserId(string uid,string rid,DataConnection db)
        {
            //获取登录用户的角色菜单，

            List<SysMenuEx> rs = null;

            var rs1 = from t1 in db.Query<SysMenu>()
                      join t2 in db.Query<SysRoleMenu>() on t1.MenuId equals t2.MenuId
                      join t3 in db.Query<SysUserRole>() on new { a = t2.RoleId, b = uid } equals new { a = t3.RoleId, b = t3.UserId }
                      join t4 in db.Query<SysRoleMenu>() on new { a = t1.MenuId, b = rid } equals new { a = t4.MenuId, b = t4.RoleId } into t5
                      from t4 in t5.DefaultIfEmpty()
                      select new SysMenuEx()
                      {
                          MenuId = t1.MenuId,
                          MenuPid = t1.MenuPid,
                          DateCreate = t1.DateCreate,
                          IsEnable = t1.IsEnable,
                          MenuIconclass = t1.MenuIconclass,
                          MenuIconurl = t1.MenuIconurl,
                          MenuName = t1.MenuName,
                          MenuSeq = t1.MenuSeq,
                          MenuUrl = t1.MenuUrl,
                          Checked = t4.MenuId == null ? false : true
                      };

              rs = rs1.ToList();

            return rs;
        }

        /// <summary>
        /// 获取对应角色的已有权限的菜单
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="rid"></param>
        /// <returns></returns>
        public List<SysMenuEx> GetMenuExByUid(string uid, string rid)
        {
            List<SysMenuEx> rs = null;
            SysUserServices sv = new SysUserServices();
            var user = sv.GetUser_ById(uid);
            string parameterSymbol = string.Empty;
            using (var db = Linq2DbConnectionManager.Get())
            {
                parameterSymbol = (db.DataProvider as LinqToDB.DataProvider.DataProviderBase).ParametersSymbol;
                //超级管理员不限角色
                if (user.IsAdmin.HasValue)
                {
                    //获取用户的角色菜单，超级管理员能看到所有菜单
                    if ((bool)user.IsAdmin)
                    {
                        //rs = db.Query<SysMenuEx>($"SELECT 	T3.*,CASE WHEN   (SELECT 1 FROM SYS_ROLE_MENU T1 WHERE T1.MENU_ID=T3.MENU_ID AND T1.ROLE_ID={parameterSymbol}rid)  IS NULL  THEN  0 ELSE  1 END  AS CHECKED  FROM  SYS_MENU T3 ", new
                        //{
                        //    rid = rid
                        //}).ToList(); 

                        rs = (from t1 in db.Query<SysMenu>()
                              join t2 in db.Query<SysRoleMenu>() on new { a = t1.MenuId, b = rid } equals new { a = t2.MenuId, b = t2.RoleId } into t3
                              from t2 in t3.DefaultIfEmpty()
                              select new SysMenuEx()
                              {
                                  MenuId = t1.MenuId,
                                  MenuPid = t1.MenuPid,
                                  DateCreate = t1.DateCreate,
                                  IsEnable = t1.IsEnable,
                                  MenuIconclass = t1.MenuIconclass,
                                  MenuIconurl = t1.MenuIconurl,
                                  MenuName = t1.MenuName,
                                  MenuSeq = t1.MenuSeq,
                                  MenuUrl = t1.MenuUrl,
                                  Checked = t2.MenuId == null ? false : true
                              }).ToList();

                    }

                    else
                    {
                        rs = GetMenuExByLoginUserId(uid, rid, db);
                    }
                }
                else
                {
                    rs = GetMenuExByLoginUserId(uid, rid, db);
                    /*
                       SELECT T3.*,
       CASE
         WHEN (SELECT 1
                 FROM SYS_ROLE_MENU T1
                WHERE T1.MENU_ID = T3.MENU_ID
                  AND T1.ROLE_ID = 'R001') IS NULL THEN
          0
         ELSE
          1
       END AS CHECKED
  FROM SYS_ROLE_MENU T1, SYS_USER_ROLE T2, SYS_MENU T3
 WHERE T1.ROLE_ID = T2.ROLE_ID
   AND T3.MENU_ID = T1.MENU_ID
   AND T2.USER_ID ='admin1'
 


                    SELECT t1.*FROM SYS_MENU T1  JOIN SYS_ROLE_MENU T2
                   ON T1.MENU_ID = T2.MENU_ID  JOIN SYS_USER_ROLE T3 ON T2.ROLE_ID = T3.ROLE_ID AND T3.USER_ID = 'admin1'

    */




                    //rs = db.Query<SysMenuEx>($" SELECT 	T3.*,CASE WHEN   (SELECT 1 FROM SYS_ROLE_MENU T1 WHERE T1.MENU_ID=T3.MENU_ID AND T1.ROLE_ID={parameterSymbol}rid)  IS NULL  THEN  0 ELSE  1 END  AS CHECKED  FROM 	SYS_ROLE_MENU T1, 	SYS_USER_ROLE T2, 	SYS_MENU T3 WHERE 	T1.ROLE_ID = T2.ROLE_ID AND T3.MENU_ID = T1.MENU_ID AND T2.USER_ID ={parameterSymbol}uid", new
                    //{
                    //    uid = uid,
                    //    rid = rid
                    //}).ToList();
                }
                return rs;
            }
        }
        /// <summary>
        /// 菜单编辑保存
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public dynamic SaveMenu(dynamic data)
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
                            db.Update<SysMenu>(new SysMenu
                            {
                                MenuPid = m.pid,
                                MenuUrl = m.file,
                                MenuName = m.text,
                                MenuIconurl = m.iconUrl,
                                MenuIconclass = m.iconCls,
                                MenuSeq = m.seq,
                                IsEnable = m.isEnable,
                                MenuId = m.id
                            });
                        }
);
                    if (lst_insert != null)
                        lst_insert.ForEach(m =>
                        {
                            db.Insert<SysMenu>(new SysMenu
                            {
                                MenuPid = m.pid,
                                MenuUrl = m.file,
                                MenuName = m.text,
                                MenuIconurl = m.iconUrl,
                                MenuIconclass = m.iconCls,
                                MenuSeq = m.seq,
                                IsEnable = m.isEnable,
                                MenuId = m.id,
                                DateCreate = DateTime.Now
                            });
                        }
);
                    if (lst_deleted != null)
                        lst_deleted.ForEach(m =>
                        {
                            string id = m.id;
                            db.Query<SysMenu>().Delete(n => n.MenuId == id);
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