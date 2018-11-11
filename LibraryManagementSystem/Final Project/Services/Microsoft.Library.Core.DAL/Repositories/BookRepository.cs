
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
    public class BookRepository : GenericRepository<tbl_Books>, IBookRepository
    {
        private LibraryDBContext Context;

        public BookRepository(LibraryDBContext Context)
            : base(Context)
        {
            this.Context = Context;
        }
        public IEnumerable<tbl_Books> SearchBooks(string columnName, string searchItems)
        {
            var query = this.dbSet.AsQueryable();

            if (columnName == "Title")
            {
                query = query.Where(x => x.Title.Contains(searchItems));
            }
            if (columnName == "Description")
            {
                query = query.Where(x => x.Description.Contains(searchItems));
            }
            if (columnName == "Category")
            {
                query = query.Where(x => x.Category.Contains(searchItems));
            }
            if (columnName == "Author")
            {
                query = query.Where(x => x.Author.Contains(searchItems));
            }
            if (columnName == "Publisher")
            {
                query = query.Where(x => x.Publisher.Contains(searchItems));
            }
            if (columnName == "ISBN No")
            {
                query = query.Where(x => x.ISBNNumber.Contains(searchItems));
            }
            return query.ToList();
        }
    }
}
