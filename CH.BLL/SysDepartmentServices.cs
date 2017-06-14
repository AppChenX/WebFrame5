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
    public class SysDepartmentServices
    {
        public List<SysDepartment> GetBy_UserId(string uid)
        {

            string parameterSymbol = string.Empty;
            using (var db = Linq2DbConnectionManager.Get())
            {
                //parameterSymbol = (db.DataProvider as LinqToDB.DataProvider.DataProviderBase).ParametersSymbol;
                //return db.Query<SysDepartment>($"SELECT T.* , CASE WHEN (SELECT  1 FROM SYS_USER_DEPARTMENT TU WHERE TU.DEPARTMENT_ID=T.DEPARTMENT_ID AND TU.USER_ID={parameterSymbol}UserId) IS NULL THEN 0 ELSE 1 END   AS Checked FROM SYS_DEPARTMENT T", new
                //{
                //    UserId = uid
                //}).ToList();

                var rs = from t1 in db.Query<SysDepartment>() join t2 in db.Query<SysUserDepartment>() on new { a=t1.DepartmentId,b=uid
                } equals new { a=t2.DepartmentId ,b=t2.UserId} into t3
                         from t2 in t3.DefaultIfEmpty()  
                          select new SysDepartment() { 
                    DepartmentId = t1.DepartmentId, DepartmentPid = t1.DepartmentPid, DepartmentName = t1.DepartmentName, Checked = t2.UserId==null ? false : true
                };

                return rs.ToList();

            }
        }
        /// <summary>
        /// 保存用户的部门
        /// </summary>
        /// <param name="data"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public dynamic Save_UserDepartment(dynamic data, string uid)
        {
            using (var db = Linq2DbConnectionManager.Get())
            {
                try
                {
                    List<dynamic> lst = JsonConvert.DeserializeObject<List<dynamic>>(data.ToString());
                    db.Query<SysUserDepartment>().Delete(m => m.UserId == uid);
                    if (lst != null)
                    {
                        lst.ForEach(m =>
                        {
                            db.Insert<SysUserDepartment>(new SysUserDepartment()
                            {
                                DepartmentId = m.DepartmentId,
                                UserId = uid
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
    }
}