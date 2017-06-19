using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CH.CodeGenerator
{
    public static class DataProviderHelper
    {

        public static LinqToDB.DataProvider.IDataProvider GetDataProvider(this DataProvider provider)
        {

            switch (provider)
            {
                case DataProvider.Oracle:

                    return new LinqToDB.DataProvider.Oracle.OracleDataProvider("OracleManaged");

                case DataProvider.Sqlserver2000:

                    return new LinqToDB.DataProvider.SqlServer.SqlServerDataProvider("SqlServer", LinqToDB.DataProvider.SqlServer.SqlServerVersion.v2000);

                case DataProvider.Sqlserver2005:

                    return new LinqToDB.DataProvider.SqlServer.SqlServerDataProvider("SqlServer", LinqToDB.DataProvider.SqlServer.SqlServerVersion.v2005);

                case DataProvider.Sqlserver2008:

                    return new LinqToDB.DataProvider.SqlServer.SqlServerDataProvider("SqlServer", LinqToDB.DataProvider.SqlServer.SqlServerVersion.v2008);

                case DataProvider.Sqlserver2010:

                    return new LinqToDB.DataProvider.SqlServer.SqlServerDataProvider("SqlServer", LinqToDB.DataProvider.SqlServer.SqlServerVersion.v2012);

                case DataProvider.MySql:

                    return new LinqToDB.DataProvider.MySql.MySqlDataProvider();

                case DataProvider.Access:

                    return new LinqToDB.DataProvider.Access.AccessDataProvider();

                case DataProvider.Sqlite:

                    return new LinqToDB.DataProvider.SQLite.SQLiteDataProvider();

                default:

                    return null;
            }

        }
    }
}
