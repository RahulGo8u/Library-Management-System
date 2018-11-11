
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
    /// Interface bidder registration.
    /// </summary>
    public interface IUserRepository : IGenericRepository<tbl_Users>
    {
        IEnumerable<tbl_Users> GetUserList(int userId, int page, int pageSize, out int totalRecord);

        tbl_Users AddUsers(tbl_Users tbl_users);
        tbl_Users Login(int userId, string password);

    }
}
