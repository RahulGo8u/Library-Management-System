
namespace Microsoft.Library.Core.DAL.UnitOfWorks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using Repositories;
    using Model;
    using System.Data.Entity;
    using DB;


    /// <summary>
    /// The unit of work class.
    /// </summary>
    public class UnitOfWorks : IUnitOfWorks
    {
        private LibraryDBContext context = new LibraryDBContext();

        private bool disposed = false;

        /// <summary>
        /// 
        /// </summary>
        private IUserRepository userRepository;

        /// <summary>
        /// 
        /// </summary>
        private IBookRepository bookRepository;

        /// <summary>
        /// 
        /// </summary>
        private ICategoryRepository categoryRepository;

        /// <summary>
        /// 
        /// </summary>
        private ITransactionRepository transactionRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(this.context);
                }
                return userRepository;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;

                this.context.Dispose();

                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IBookRepository BookRepository
        {
            get
            {
                if (this.bookRepository == null)
                {
                    this.bookRepository = new BookRepository(this.context);
                }
                return bookRepository;
            }
        }


        public ICategoryRepository CategoryRepository
        {
            get {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(this.context);
                }
                return categoryRepository;
            }
        }


        public ITransactionRepository TransactionRepository
        {

            get
            {
                if (this.transactionRepository == null)
                {
                    this.transactionRepository = new TransactionRepository(this.context);
                }
                return transactionRepository;
            }
        }
    }
}
