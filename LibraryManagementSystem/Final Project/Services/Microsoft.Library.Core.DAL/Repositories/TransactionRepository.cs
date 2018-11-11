
namespace Microsoft.Library.Core.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using DB;
    using Microsoft.Library.Core.Model;
    using GenericRepositories;

    /// <summary>
    /// The Application registration.
    /// </summary>
    public class TransactionRepository : GenericRepository<tbl_Transaction>, ITransactionRepository
    {
        private LibraryDBContext Context;

        public TransactionRepository(LibraryDBContext Context)
            : base(Context)
        {
            this.Context = Context;
        }
        public IEnumerable<tbl_Transaction> GetAllTransaction()
        {
            return this.dbSet.ToList();
        }

        public IEnumerable<tbl_Transaction> GetSelfTransaction(int userId)
        {
            var result= this.dbSet.Where(x => x.UserId ==userId);
            
            return result.ToList();
        }

        public IEnumerable<tbl_Transaction> GetDetailsbyId(int bookId)
        {
            var result = this.dbSet.Where(x => x.BookId == bookId);

            return result.ToList();
        }

        public IEnumerable<tbl_Transaction> GetDetailsbyUserId(int userId)
        {
            var result = this.dbSet.Where(x => x.UserId == userId);

            return result.ToList();
        }
        
    }
}
