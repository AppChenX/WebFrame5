using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Domain.Uow;
using LinqToDB.Data;
using System.Data;
namespace LinqToDB
{
    public class Linq2DbTransactionWrapper : ITransactionable
    {
        public DataConnection InternalDbSession { get; private set; }

        public Linq2DbTransactionWrapper(DataConnection session)
        {
            InternalDbSession = session;
        }

        public void BeginTransaction(IsolationLevel level = IsolationLevel.ReadCommitted)
        {
            InternalDbSession.BeginTransaction(level);
        }

        public void Commit()
        {
            InternalDbSession.CommitTransaction();
        }

        public void Dispose()
        {
            InternalDbSession.Dispose();
        }

        public void Rollback()
        {
            InternalDbSession.RollbackTransaction();
        }
    }
}
