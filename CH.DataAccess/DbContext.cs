using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
namespace DataAccess
{
    //public class DbConext : LinqToDB.Data.DataConnection
    //{



    //    public DbConext(string constr="default") : base(constr) {

           
    //    }



    //    public ITable<T> Query<T>() where T : class
    //    {
    //        return GetTable<T>();
    //    }

    //}

    public static class DataConnectionEx
    {

        public static ITable<T> Query<T>(this LinqToDB.Data.DataConnection con) where T : class
        {
            return con.GetTable<T>();
        }

    }
}

    
