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
    public class SysUserServices
    {
        /// <summary>
        /// 通过用户角色获取ID
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public List<SysUser> Get_ByRoleId(string rid)
        {
            using (var db = Linq2DbConnectionManager.Get())
            {
                
                var m = from a in db.Query<SysUser>() from c in db.Query<SysUserRole>() where a.UserId.Equals(c.UserId) && c.RoleId == rid select a;
                return m.ToList();
            }
        }
        /// <summary>
        /// 通过用户ID获取用户
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public SysUser GetUser_ById(string uid)
        {
            using (var db = Linq2DbConnectionManager.Get())
            {
                return db.Query<SysUser>().Where(m => m.UserId == uid).FirstOrDefault();
            }
        }
        public StatusMessage ForgetPwd(string userName, string userEmail, string verifyCode, string codeServer, Action EmailSendHandler)
        {
            string _code = string.Empty;
            var rs = new StatusMessage();
            rs.status = "N";
            try
            {
                if (string.IsNullOrEmpty(userName))
                {
                    throw new Exception("用户名不能为空");
                }
                if (string.IsNullOrEmpty(userEmail))
                {
                    throw new Exception("邮件地址不能为空");
                }
                if (string.IsNullOrEmpty(verifyCode))
                {
                    throw new Exception("验证码不能为空");
                }
                if (string.IsNullOrEmpty(codeServer))
                {
                    throw new Exception("请刷新验证码");
                }
                var user = this.GetUser_ById(userName);
                if (user == null)
                {
                    throw new Exception("用户不存在");
                }
                if (verifyCode.ToUpper() != codeServer.ToUpper())
                {
                    throw new Exception("验证码不正解");
                }
                if (user != null)
                {
                    if (user.UserEmail != userEmail)
                    {
                        throw new Exception("邮箱地址不存在");
                    }
                }
                EmailSendHandler();
                rs.status = "Y";
                return rs;
            }
            catch (Exception ex)
            {
                rs.status = "N";
                rs.msg = ex.Message;
                return rs;
            }
        }


     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="uid"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<SysUser> GetUserByMaster_Page(dynamic data, string uid, out int total)
        {
            //通过角色获取该角色下的所有用户
            //WITH F AS ( SELECT T. * FROM Sys_Role_Member T WHERE T.Role_PID IN (SELECT TR.Role_Id FROM Sys_User_Role TR WHERE TR.User_Id='admin5') 		UNION ALL 		SELECT T1. * FROM Sys_Role_Member  AS T1 INNER JOIN F AS T2 ON T1.ROLE_PID = T2.ROLE_ID)  SELECT  TU.*   FROM F LEFT JOIN Sys_Role T ON T.Role_Id=F.Role_Id JOIN Sys_User_Role TR ON TR.Role_Id=T.Role_Id JOIN Sys_User TU ON TR.User_Id=TU.User_Id    ///sqlserver 写法
            var user = this.GetUser_ById(uid);
            if (user != null)
            {
                if (user.IsAdmin.HasValue)
                {
                    if ((bool)user.IsAdmin)
                    {
                        return GetUserByPage(data, out total);
                    }
                }
                string parameterSymbol = string.Empty;
                string sql_Total = string.Empty;
                string sql_Page = string.Empty;
                var d = data as DynamicParameters;
                var map = d.map as Dictionary<string, object>;
                string userId = !map.ContainsKey("userId") ? "" : data.userId.ToString();
                string userName = !map.ContainsKey("userName") ? "" : data.userName.ToString();
                using (var db = Linq2DbConnectionManager.Get())
                {


                     var users= db.Query<SysUserRole>().Where(m => m.UserId == uid).ToList();

                     var item_user = users.FirstOrDefault(); 

                    var roles =new CommonData().GetRoleMember(item_user.RoleId, db);

                    var s_roles = roles.Select(m => m.RoleId).ToList(); 

                    var pageUsers = from t1 in db.Query<SysUser>() from t2 in db.Query<SysUserRole>() where t1.UserId == t2.UserId && s_roles.Contains(t2.RoleId) orderby t1.UserId ascending select t1 ;


                    int page = Convert.ToInt32(data.page);
                    int rows = Convert.ToInt32(data.rows);

                    total = pageUsers.Count();

                    var rs = pageUsers.Skip((page - 1) * rows).Take(rows).ToList();

                    return rs; 

                }
            }
            else
            {
                total = 0;
                return null;
            }
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="data"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<SysUser> GetUserByPage(dynamic data, out int total)
        {
            
            string parameterSymbol = string.Empty;  
            string sql_Total = string.Empty; 
            string sql_Page = string.Empty;
            string sql_concat = string.Empty;
            using (var db = Linq2DbConnectionManager.Get())
            {
                
                    // parameterSymbol = (db.DataProvider as LinqToDB.DataProvider.DataProviderBase).ParametersSymbol;

                    //sql_concat = parameterSymbol == ":" ? "||" : "+";

                    //  sql_Total = $"SELECT COUNT(1) FROM SYS_USER T  WHERE T.USER_ID LIKE  {parameterSymbol}UserId{sql_concat}'%' AND T.USER_NAME LIKE '%'{sql_concat}{parameterSymbol}UserName{sql_concat}'%'  ";

                    //  sql_Page = $"SELECT TA.* FROM (SELECT T.*,ROW_NUMBER() OVER(ORDER BY T.USER_ID)RN  FROM SYS_USER T  WHERE T.USER_ID LIKE  {parameterSymbol}UserId{sql_concat}'%' AND T.USER_NAME LIKE '%'{sql_concat}{parameterSymbol}UserName{sql_concat}'%')TA WHERE TA.RN>=({parameterSymbol}PageNums-1)*({parameterSymbol}RowNums+1) AND TA.RN<{parameterSymbol}PageNums*({parameterSymbol}RowNums+1)";

                    var d = data as DynamicParameters;
                    var map = d.map as Dictionary<string, object>;
                    string userId = !map.ContainsKey("userId") ? "" : data.userId.ToString();
                    string userName = !map.ContainsKey("userName") ? "" : data.userName.ToString();
                    int page = Convert.ToInt32(data.page);
                    int rows = Convert.ToInt32(data.rows);


                var pageUsers = from t1 in db.Query<SysUser>() where t1.UserId.Contains(userId) && t1.UserName.Contains(userName) orderby t1.UserId ascending select t1;

                total = pageUsers.Count();

                var rs = pageUsers.Skip((page - 1) * rows).Take(rows).ToList();

                return rs;

              

            }
        }
        public List<SysUser> GetUser()
        {
            using (var db = Linq2DbConnectionManager.Get())
            {
                return db.Query<SysUser>().ToList();
            }
        }
      
        public void SigninLog(string localIp, string netIp, string addres, string userId, string userName)
        {
            using (var db = Linq2DbConnectionManager.Get())
            {
                db.Insert<SysSiginLog>(new SysSiginLog()
                {
                    LocalIp = localIp,
                    NetIp = netIp,
                    UserId = userId,
                    UserName = userName,
                    LoginAddress = addres
                });
            }
        }
        /// <summary>
        /// 验证用户登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userpwd"></param>
        /// <param name="code"></param>
        /// <param name="codeServer"></param>
        /// <param name="localip"></param>
        /// <param name="netip"></param>
        /// <param name="addres"></param>
        /// <param name="logHandler"></param>
        /// <returns></returns>
        public string[] AuthorizedUserLogin(string username, string userpwd, string code, string codeServer, string localip, string netip, string addres, Action<string, string, string, string, string> logHandler)
        {
            string status = "N";
            string msg = string.Empty;
            string _code = string.Empty;
            if (string.IsNullOrEmpty(username))
            {
                msg = "用户名不能为空";
            }
            else if (string.IsNullOrEmpty(userpwd))
            {
                msg = "密码不能为空";
            }
            else if (string.IsNullOrEmpty(code))
            {
                msg = "验证码不能为空";
            }
            else if (codeServer == null)
            {
                msg = "请刷新验证码";
            }
            else if (code.ToUpper() != codeServer.ToUpper())
            {
                msg = "验证码错误";
            }
            else
            {
                var user = this.GetUser_ById(username);
                if (user == null)
                {
                    msg = "用户名不存在";
                }
                else
                {
                    if (user.UserPwd != userpwd)
                    {
                        msg = "密码错误!";
                    }
                    else
                    {
                        status = "Y";
                        FormsAuth.SignIn(user.UserId, 60 * 24);
                        logHandler(localip, netip, addres, user.UserId, user.UserName);
                    }
                }
            }
            return new string[]
            {
                            status,msg
            }
            ;
        }
        public dynamic SaveUser(dynamic data, string uid)
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
                        lst_updated.ForEach(m => {
                            db.Update<SysUser>(new SysUser
                            {
                                UserName = m.UserName,
                                UserEmail = m.UserEmail,
                                UserMobile = m.UserMobile,
                                IsEnable = m.IsEnable,
                                UserSex = m.UserSex,
                                UserAddress = m.UserAddress,
                                UserId = m.UserId
                            });
                        }
);
                    if (lst_insert != null)
                        lst_insert.ForEach(m =>
                        {
                            db.Insert<SysUser>(new SysUser
                            {
                                UserPwd = "e10adc3949ba59abbe56e057f20f883e",
                                UserName = m.UserName,
                                UserEmail = m.UserEmail,
                                UserMobile = m.UserMobile,
                                IsEnable = m.IsEnable,
                                UserSex = m.UserSex,
                                UserAddress = m.UserAddress,
                                UserId = m.UserId,
                                CreaterId = uid
                            });
                        }
);
                    if (lst_deleted != null)
                        lst_deleted.ForEach(m =>
                        {
                            string userId = m.UserId;
                            if (!m.IsAdmin)
                                db.Query<SysUser>().Delete(n => n.UserId == userId);
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