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
using Newtonsoft.Json.Linq;
namespace CH.Web.Areas.Sys.Controllers
{
    public class SysMenuController : Controller
    {
        //
        // GET: /Sys/SysMenu/
        [MenuPermissionAttribute]
        public ActionResult Index()
        {
            return View();
        }

    }

    public class SysMenuApiController : ApiController
    {
        ////
        //// GET: /Sys/SysMenu/

        ////[System.Web.Http.AllowAnonymous]

        ///// <summary>
        ///// 获取所有菜单，注意只能是超级管理员才能编辑此模块
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable<dynamic> GetMenu()
        //{

        //    var SysMenService = new SysMenuServices();
        //    var lst_SysMenu= SysMenService.GetAll();

        //    return lst_SysMenu.Select(m => new {

        //        id = m.MenuId,
        //        pId = m.MenuPid,
        //        name = m.MenuName,
        //        file = m.MenuUrl,
        //        icon=m.MenuIconurl,
        //        iconCls= m.MenuIconclass
        //    });

        //}
     

        /// <summary>
        /// 根据用户登录ID获取对应的角色权限菜单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// 
        [ApiPermission]
        [System.Web.Http.HttpPost]
        //public IEnumerable<dynamic> PostMenuByUserId(dynamic data,string id)   url: '/api/sys/SysMenuApi/PostMenuByUserId/123',
    public IEnumerable<dynamic> PostMenuByUserId(dynamic data )
        {

            var SysMenService = new SysMenuServices();

            string uid = string.Empty;
            if(data!=null)
            {
                if(data.uid !=null)
                {
                    uid = data.uid;
                }
            }
            var lst_SysMenu = SysMenService.GetMenuByUid(uid); 

            return lst_SysMenu.Select(m => new
            {

                id = m.MenuId,
                pId = m.MenuPid,
                name = m.MenuName,
                file = m.MenuUrl,
                icon = m.MenuIconurl,
                iconCls = m.MenuIconclass
            });
        }


        /// <summary>
        /// 获取菜单对应的按钮权限
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [ApiPermission]
        [System.Web.Http.HttpPost]
        public IEnumerable<dynamic> PostMenuAction(dynamic data)
        {

            var SysMenService = new SysMenuServices();

            string uid = string.Empty;
            string rid = string.Empty;
            if (data != null)
            {
                if (data.uid != null)
                {
                    uid = data.uid;
                    rid = data.rid;
                }
            }
            var lst_SysMenu = SysMenService.GetMenuAndAction(uid,rid);

            return lst_SysMenu.Select(m => new
            {

                id = m.MenuId,
                pId = m.MenuPid,
                name = m.MenuName,
                file = m.MenuUrl,
                icon = m.MenuIconurl,
                iconCls = m.MenuIconclass,
                @checked = m.Checked,
                nocheck=m.NCheck
            });
        } 


        /// <summary>
        /// 获取对应用户菜单和编辑角色的菜单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [ApiPermission]
        [System.Web.Http.HttpPost] 
        public IEnumerable<dynamic> PostMenuExByUserId(dynamic data)
        {

            var SysMenService = new SysMenuServices();

            string uid = string.Empty;
            string rid = string.Empty;
            if (data != null)
            {
                if (data.uid != null)
                {
                    uid = data.uid;
                    rid = data.rid;
                }
            }
            var lst_SysMenu = SysMenService.GetMenuExByUid(uid,rid);

            return lst_SysMenu.Select(m => new
            {

                id = m.MenuId,
                pId = m.MenuPid,
                name = m.MenuName,
                file = m.MenuUrl,
                icon = m.MenuIconurl,
                iconCls = m.MenuIconclass,
                @checked=m.Checked
            });
        } 
        /// <summary>
        /// 菜单管理数据源
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public IEnumerable<dynamic> GetMenuData()
        {
            var SysMenService = new SysMenuServices();
            var lst_SysMenu = SysMenService.GetAll();
            return lst_SysMenu.Select(m => new
            {

                id = m.MenuId,
                pid = m.MenuPid,
                text = m.MenuName,
                file = m.MenuUrl,
                iconUrl = m.MenuIconurl,
                iconCls = m.MenuIconclass,
                isEnable = m.IsEnable,
                seq = m.MenuSeq
            });
        }


        /// <summary>
        /// 编辑保存菜单数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public dynamic EditMenu(dynamic data)
        { 
            var sv = new SysMenuServices();

            return sv.SaveMenu(data); 
        }



        /// <summary>
        /// 编辑角色对应的菜单
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public dynamic EditMenuRole(dynamic data, string id)
         {
             
             var sv = new SysMenuServices();

             return sv.SaveMenuRole(data, id);


         }
      
    }
}
