
namespace Microsoft.Library.Core.DAL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DB;
    using Microsoft.Library.Core.Model;
    using Microsoft.Library.Core.DAL.GenericRepositories;

    /// <summary>
    /// Interface application registration.
    /// </summary>
    
    public interface ITransactionRepository : IGenericRepository<tbl_Transaction>
    {
        IEnumerable<tbl_Transaction> GetAllTransaction();
        
        IEnumerable<tbl_Transaction> GetSelfTransaction(int userId);

        IEnumerable<tbl_Transaction> GetDetailsbyId(int bookId);
        
        IEnumerable<tbl_Transaction> GetDetailsbyUserId(int userId);
    }
}
