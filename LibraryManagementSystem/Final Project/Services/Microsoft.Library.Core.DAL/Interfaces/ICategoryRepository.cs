
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
    
    public interface ICategoryRepository : IGenericRepository<tbl_Category>
    {
      IEnumerable<tbl_Category> GetAllCategory();
      
    }
}
