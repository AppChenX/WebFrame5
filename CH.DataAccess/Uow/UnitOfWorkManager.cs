 
using System;

namespace DataAccess.Domain.Uow
{
    #region UnitOfWorkManager
    /// <summary>
    /// 基于多数据库的可串联的事务。
    /// 1.部分数据库不支持分布式数据库
    /// 2.使用微软自带的事务容易提升事务级别为分布式，需要特定的数据库客户端。
    /// 3.防止升级DTC，提高系统性能。参见博客园：蒋金楠（Artech）像TransactionScope一样使用DbTransaction。
    /// 4.通过Complete方法进行提交事务，未提交则自动回滚
    /// http://www.cnblogs.com/artech/archive/2012/01/05/custom-transaction-scope.html
    /// 关于事务隔离级别：http://www.cnblogs.com/otomedaybreak/archive/2012/01/27/2330008.html
    /// 大部分数据库或者nhibernate的默认隔离级别都是（ReadCommited 可读已提交）
    /// 逻辑：现有事务，然后获取数据库连接的时候决定【新开连接并开启事务】还是【获取事务的连接】
    /// </summary>
    public class UnitOfWorkManager : IDisposable
    {
        private bool completed = false;
        private readonly UnitOfWork expectedCurrent;
        private readonly UnitOfWork savedCurrent = UnitOfWork.Current;
        //static readonly ILogger log = LogManager.Default;

        public UnitOfWorkManager(UnitOfWorkScopeOption scopeOption = UnitOfWorkScopeOption.Required, System.Data.IsolationLevel level = System.Data.IsolationLevel.ReadCommitted)
        {
            if (scopeOption == UnitOfWorkScopeOption.Required && UnitOfWork.Current != null)
            {
                this.expectedCurrent = UnitOfWork.Current.DependentClone();
            }
            if ((scopeOption == UnitOfWorkScopeOption.Required && UnitOfWork.Current == null) || scopeOption == UnitOfWorkScopeOption.RequiresNew)
            {
                var commitableTransaction = new CommittableUnitOfWork(level);
                this.expectedCurrent = commitableTransaction;
            }
            if (scopeOption == UnitOfWorkScopeOption.Suppress)
            {
                this.expectedCurrent = null;
            }

            UnitOfWork.Current = expectedCurrent;
        }

        public UnitOfWork Current { get { return UnitOfWork.Current; } }

        /// <summary>
        /// 开启一个事务范围，在嵌套事务中则开启依赖事务
        /// </summary> 
        public static UnitOfWorkManager Required()
        {
            return new UnitOfWorkManager(UnitOfWorkScopeOption.Required);
        }
        /// <summary>
        /// 无论是否存在嵌套事务，总是开启一个新的事务范围
        /// </summary> 
        public static UnitOfWorkManager RequiresNew()
        {
            return new UnitOfWorkManager(UnitOfWorkScopeOption.RequiresNew);
        }
        /// <summary>
        /// 开启一个事务范围，在这个范围内的操作不受事务控制
        /// </summary> 
        public static UnitOfWorkManager Suppress()
        {
            return new UnitOfWorkManager(UnitOfWorkScopeOption.Suppress);
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void Complete()
        {
            this.completed = true;
        }

        public void Dispose()
        {
            var message = string.Empty;
            var current = UnitOfWork.Current;
            UnitOfWork.Current = this.savedCurrent;
            Exception error = null;

            if (current != null)
            {
                if (!this.completed)
                {
                    current.Rollback();
                }
                
                var committableTransaction = current as CommittableUnitOfWork;
                if (null != committableTransaction)
                {
                    if (this.completed)
                    {
                        try
                        {
                            committableTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            current.Rollback();
                            error = ex;
                        }
                    }
                    committableTransaction.Dispose();
                }
            }

            if (error != null) throw error;
        }
    }
    #endregion

    #region UnitOfWorkScopeOption
    public enum UnitOfWorkScopeOption
    {
        Required,
        RequiresNew,
        Suppress
    }
    #endregion
}
