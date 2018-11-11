
namespace Microsoft.Library.Core.DAL.UnitOfWorks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GenericRepositories;
    using Interfaces;
    using Repositories;
    using Model;

    /// <summary>
    /// Interface unitofworks.
    /// </summary>
    public interface IUnitOfWorks : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        IUserRepository UserRepository { get; }

        /// <summary>
        /// 
        /// </summary>
        IBookRepository BookRepository { get; }

        /// <summary>
        /// 
        /// </summary>
        ICategoryRepository CategoryRepository { get; }

        /// <summary>
        /// 
        /// </summary>
        ITransactionRepository TransactionRepository { get; }

        /// <summary>
        /// 
        /// </summary>
        void Save();
    }
}
