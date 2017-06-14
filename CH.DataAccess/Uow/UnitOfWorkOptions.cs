using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GlueNet.Domain.Uow
{
    /// <summary>
    /// Unit of work options.
    /// </summary>
    public class UnitOfWorkOptions
    {
        /// <summary>
        /// Scope option.
        /// </summary>
        public UnitOfWorkScopeOption? Scope { get; set; } = UnitOfWorkScopeOption.Required;
 
        /// <summary>
        /// Timeout of UOW As milliseconds.
        /// Uses default value if not supplied.
        /// </summary>
        public TimeSpan? Timeout
        {
            get;
            set;
        }

        /// <summary>
        /// If this UOW is transactional, this option indicated the isolation level of the transaction.
        /// Uses default value if not supplied.
        /// </summary>
        public IsolationLevel? IsolationLevel { get; set; } = System.Data.IsolationLevel.ReadCommitted;

        /// <summary>
        /// Creates a new <see cref="T:Abp.Domain.Uow.UnitOfWorkOptions" /> object.
        /// </summary>
        public UnitOfWorkOptions()
        {
        }
    }
}
