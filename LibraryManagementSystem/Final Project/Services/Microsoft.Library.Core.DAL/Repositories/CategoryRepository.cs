
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
    public class CategoryRepository : GenericRepository<tbl_Category>, ICategoryRepository
    {
        private LibraryDBContext Context;

        public CategoryRepository(LibraryDBContext Context)
            : base(Context)
        {
            this.Context = Context;
        }

        public IEnumerable<tbl_Category> GetAllCategory()
        {
            return this.dbSet.ToList();
        }
       
    }
}
