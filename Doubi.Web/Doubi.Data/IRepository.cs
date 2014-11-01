using FluentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Data
{
    /// <summary>
    /// Repository
    /// </summary>
    public partial interface IRepository<T>
    {
        /// <summary>
        /// 从数据库获取一个Domain对象的实例
        /// </summary>
        /// <param name="id">The id of the entity. </param>
        /// <returns>The resolved entity</returns>
        T GetById(int id);

        /// <summary>
        /// 在数据库中保存新增对象
        /// </summary>
        /// <param name="entity">An entity instance that should be saved to the database.</param>
        /// <remarks>Implementors should delegate this to the current <see cref="IDbContext" /></remarks>
        bool Insert(T entity);

        /// <summary>
        /// 使用事务在数据库中保存新增对象
        /// </summary>
        /// <param name="entity">domian对象</param>
        /// <param name="context"></param>
        void InsertWithTransaction(T entity, IDbContext context);

        /// <summary>
        /// 在数据库中批量保存新增对象
        /// </summary>
        /// <param name="entities">The list of entity instances to be saved to the database</param>
        /// <param name="batchSize">The number of entities to insert before saving to the database (if <see cref="AutoCommitEnabled"/> is true)</param>
        void InsertRange(IEnumerable<T> entities, int batchSize = 100);

        /// <summary>
        /// 在数据库中更新单条数据
        /// </summary>
        /// <param name="entity">An instance that should be updated in the database.</param>
        /// <remarks>Implementors should delegate this to the current <see cref="IDbContext" /></remarks>
        bool Update(T entity);

        /// <summary>
        /// 使用事务在数据库中更新单条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="context"></param>
        void UpdateWithTransaction(T entity, IDbContext context);

        /// <summary>
        /// 在数据库中删除单条数据.
        /// </summary>
        /// <param name="entity">An entity instance that should be deleted from the database.</param>
        /// <remarks>Implementors should delegate this to the current <see cref="IDbContext" /></remarks>
        bool Delete(T entity);

        /// <summary>
        /// 根据id删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 返回全部数据
        /// </summary>
        /// <returns></returns>
        List<T> SelectAll();

        /// <summary>
        /// 限定条件返回全部数据
        /// </summary>
        /// <returns></returns>
        List<T> SelectAll(string sortExpression);

        /// <summary>
        /// 限定条件返回部分数据
        /// </summary>
        /// <returns></returns>
        List<T> SelectAll(int startRowIndex, int maximumRows, string sortExpression);
    }
}
