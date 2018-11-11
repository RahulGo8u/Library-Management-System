
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
    /// The Bidder registration.
    /// </summary>
    public class UserRepository : GenericRepository<tbl_Users>, IUserRepository
    {
        private LibraryDBContext Context;

        public UserRepository(LibraryDBContext Context)
            : base(Context)
        {
            this.Context = Context;
        }

        public IEnumerable<tbl_Users> GetUserList(int userId, int page, int pageSize, out int totalRecord)
        {
            var result = this.dbSet.Where(x => x.UserId == userId);

            totalRecord = result.Count();

            return result.ToList();
        }

        public tbl_Users AddUsers(tbl_Users tbl_users)
        {
            return this.dbSet.Add(tbl_users);
        }

        public tbl_Users Login(int userId, string password)
        {

            var result = this.dbSet.Where(x => x.UserId == userId && x.Password == password).FirstOrDefault();
            return result;
        }
    }
}
