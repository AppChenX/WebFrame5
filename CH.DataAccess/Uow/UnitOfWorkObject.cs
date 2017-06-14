using System;
using System.Linq;

namespace GlueNet.Domain.Uow
{
    public class UnitOfWorkObject<T> : IDisposable where T : IDisposable
    {
        private T db;
        public T Context { get { return this.db; } }

        public UnitOfWorkObject(T db)
        {
            this.db = db;
        }
        public void Dispose()
        {
            if (db != null && UnitOfWork.Current == null)
            {
                db.Dispose();
                db = default(T);
            }
        }
    }
}
