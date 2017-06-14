using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess.Domain.Uow
{
    #region ITransactionable
    /// <summary>
    /// 可以执行事务的对象
    /// </summary>
    public interface ITransactionable : IDisposable
    {
        void BeginTransaction(IsolationLevel level = IsolationLevel.ReadCommitted);
        void Commit();
        void Rollback();
    }
    #endregion

    #region abstract UnitOfWork
    /// <summary>
    /// 事务的抽象类，可以实现为可提交事务和依赖事务
    /// </summary>
    public abstract class UnitOfWork : IDisposable
    {
        [ThreadStatic]
        private static UnitOfWork current;
        public static UnitOfWork Current
        {
            get { return current; }
            set { current = value; }
        }

        public virtual IsolationLevel IsolationLevel
        { get; set; }
        public virtual Dictionary<string, ITransactionable> TransactionableList
        { get; private set; }

        protected UnitOfWork()
        {
            this.CreationTime = DateTime.Now;
            this.LocalIdentifier = Guid.NewGuid().ToString("N");
            this.TransactionableList = new Dictionary<string, ITransactionable>();
        }

        internal void Rollback()
        {
            foreach (var worker in TransactionableList.Values)
            {
                try { worker.Rollback(); } catch { }
            }
        }

        public DependentUnitOfWork DependentClone()
        {
            return new DependentUnitOfWork(this);
        }

        public void Dispose()
        {
            foreach (var worker in TransactionableList.Values)
            {
                try { worker.Dispose(); } catch { }
            }
        }

        public bool IsCompleted
        { get; private set; }

        public DateTime CreationTime { get; private set; }
        public string LocalIdentifier { get; private set; }

        public event EventHandler Completed;

        protected string ExcuteCompletedEvents()
        {
            try
            {
                Completed?.Invoke(this, null);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
    #endregion

    #region CommittableUnitOfWork
    /// <summary>
    /// 可提交工作单元
    /// </summary>
    public class CommittableUnitOfWork : UnitOfWork
    {
        public CommittableUnitOfWork(IsolationLevel level)
        {
            this.IsolationLevel = level;
        }
        public void Commit()
        {
            foreach (var worker in TransactionableList.Values)
            {
                worker.Commit();
            }
        }
    }
    #endregion

    #region DependentUnitOfWork
    /// <summary>
    /// 依赖工作单元
    /// </summary>
    public class DependentUnitOfWork : UnitOfWork
    {
        public UnitOfWork InnerTransaction { get; private set; }
        internal DependentUnitOfWork(UnitOfWork innerTransaction)
        {
            this.InnerTransaction = innerTransaction;
        }
        public override Dictionary<string, ITransactionable> TransactionableList
        {
            get
            {
                return this.InnerTransaction.TransactionableList;
            }
        }
        public override IsolationLevel IsolationLevel
        {
            get
            {
                return this.InnerTransaction.IsolationLevel;
            }
            set
            {
                this.InnerTransaction.IsolationLevel = value;
            }
        }
    }
    #endregion
}