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
    public class SysRoleMenuServices
    {
        public List<SysUserRole> GetAll_RoleMenu()
        {
            using (var db = Linq2DbConnectionManager.Get())
            {
                return (db.Query<SysUserRole>().ToList());
            }
        }
    }
}