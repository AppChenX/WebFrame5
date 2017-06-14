using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web;
using CH.BLL;
using CH.Model;
using CH.Common;
namespace CH.Web.Areas.Sys.Controllers
{
    public class SysRoleController : Controller
    {
        //
        // GET: /Sys/SysRole/

        public ActionResult Index()
        {
            return View();
        }

    }

    public class SysRoleApiController : ApiController
    {

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public IEnumerable<dynamic> GetSysRole(RequestWrapper request)
        {

            var sv = new SysRoleServices();

            return sv.GetAll(); 

        }



        /// <summary>
        /// 保存角色下的所属角色
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public dynamic EditRoleMember(dynamic data, string id)
        {

            var sv = new SysRoleMemberSevices();

            return sv.SaveRoleMember(data, id);

        }

        /// <summary>
        /// 通过用户ID获取该用户ID角色下的所有角色
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public dynamic  GetRoleByUserId(dynamic data,string id)
        {

            var sv = new SysRoleServices();

            return sv.Get_ByUserId(id);

        }


        /// <summary>
        /// 保存角色数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public dynamic EditRole(dynamic data)
        {


            var sv = new SysRoleServices();

            return sv.SaveRole(data);


        }


        /// <summary>
        /// 编辑用户角色
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id"></param>
        /// <returns></returns>
         [System.Web.Http.HttpPost]
        public dynamic EditUserRole(dynamic data,string id)
        {
            var sv = new SysRoleServices();

            return sv.SaveUserRole(data,id);
        }


        /// <summary>
        /// 通过用户选择来操作用户角色
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id"></param>
        /// <returns></returns>
           [System.Web.Http.HttpPost]
         public dynamic EditUserRole1(dynamic data)
        {
            var sv = new SysRoleServices();

            return sv.SaveUserRole1(data);
        }

      

        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         [System.Web.Http.HttpPost]
         public dynamic PostRoleByUserId(dynamic data )
         {
             var sv = new SysRoleServices(); 
             string uid = data.userId;
             return sv.GetByUserId(uid);
         }


        
        /// <summary>
        /// 查找角色所属性角色 
        /// </summary>
        /// <param name="data">{roleId:'xxx'}</param>
        /// <returns></returns>
            [System.Web.Http.HttpPost]
         public dynamic PostRoleMember(dynamic data)
         {
             var sv = new SysRoleMemberSevices(); 
             string rid = data.roleId;
             return sv.Get_ByRoleId(rid);
         }


    }
}


/*
 * 
 *  ORACLE 查询树 SELECT   *   FROM SYS_ROLE_OWN T   START WITH   T.ROLE_ID = 'R001'  CONNECT  BY PRIOR ROLE_ID = ROLE_PID  
 *  
 *  SQLSERVER 查询树    
 * WITH F AS
(
	SELECT T. * FROM SYS_ROLE_OWN T WHERE T.ROLE_ID = 'R002'
		UNION ALL
		SELECT T1. * FROM SYS_ROLE_OWN AS T1 INNER JOIN F AS T2 ON T1.ROLE_PID = T2.ROLE_ID)

SELECT * FROM F
 * 
 * 
 */