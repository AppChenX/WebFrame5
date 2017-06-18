using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Data;
using DataAccess.Domain.Uow;
namespace LinqToDB
{
    public class Linq2DbConnectionManager
    {


   
        public static DataConnection Get(string connectionStringName = "default")
        {
            if (UnitOfWork.Current != null)
            {
#if !NOASYNC
                var key = $"{nameof(Linq2DbConnectionManager)}.{connectionStringName}";



#else
                  var key = string.Format("{0}.{1}", "Linq2DbConnectionManager", connectionStringName); 
#endif
                //var key = $"{nameof(Linq2DbConnectionManager)}.{connectionStringName}";
                if (!UnitOfWork.Current.TransactionableList.ContainsKey(key))
                {
                    var wrapper = new Linq2DbTransactionWrapper(CreateInternal(connectionStringName));
                    wrapper.BeginTransaction(UnitOfWork.Current.IsolationLevel);
                    UnitOfWork.Current.TransactionableList[key] = wrapper;
                }

                var transaction = UnitOfWork.Current.TransactionableList[key] as Linq2DbTransactionWrapper;
                return transaction.InternalDbSession;
            }

            return CreateInternal(connectionStringName);
        }

        private static DataConnection CreateInternal(string connectionStringName)
        {
            var configuration = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName];
            var dataprovider = DataConnection.GetDataProvider(connectionStringName);
            return new DataConnection(dataprovider, configuration.ConnectionString);
        }
    }




}
