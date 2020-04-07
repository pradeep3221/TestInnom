using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace TestInnom.Product.DataAccess.DAL
{
    /// <summary>
    /// </summary>
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Gets all objects from database
        /// </summary>
        /// <returns></returns>
        IQueryable<T> All<T>(string[] includes = null) where T : class;

        /// <summary>
        /// Select Single Item by specified expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        T Get<T>(Expression<Func<T, bool>> expression, string[] includes = null) where T : class;

        /// <summary>
        /// Create a new object to database.
        /// </summary>
        /// <param name="t">Specified a new object to create.</param>
        /// <returns></returns>
        T Create<T>(T t) where T : class;

        /// <summary>
        /// Delete the object from database.
        /// </summary>
        /// <param name="t">Specified a existing object to delete.</param>
        int Delete<T>(T t) where T : class;

        /// <summary>
        /// Delete objects from database by specified filter expression.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Delete<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Update object changes and save to database.
        /// </summary>
        /// <param name="t">Specified the object to save.</param>
        /// <returns></returns>
        int Update<T>(T t) where T : class;

        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Executes the procedure.
        /// </summary>
        /// <param name="procedureCommand">The procedure command.</param>
        /// <param name="sqlParams">The SQL params.</param>
        void ExecuteProcedure(String procedureCommand, params SqlParameter[] sqlParams);
    }
}
