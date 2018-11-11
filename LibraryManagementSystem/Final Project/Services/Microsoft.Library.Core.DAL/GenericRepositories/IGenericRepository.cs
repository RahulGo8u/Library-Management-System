namespace Microsoft.Library.Core.DAL.GenericRepositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface IGeneric repository.
    /// </summary>
    public interface IGenericRepository<TEntity>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter=null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy=null, string includeProperties="");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        TEntity GetByID(Expression<Func<TEntity, bool>> filter, string includeProperties="");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(object id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityToDelete"></param>
        void Delete(TEntity entityToDelete);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityToUpdate"></param>
        void Update(TEntity entityToUpdate);
    }
}
