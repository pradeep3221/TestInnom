using System.Collections.Generic;
using System.Linq;
using TestInnom.Product.DataAccess;

namespace TestInnom.Product.Manager
{
    public interface IBaseManager<TEntity>
        where TEntity : class
    {
        TEntity Add(TEntity t);
        IEnumerable<TEntity> AddAll(IEnumerable<TEntity> tList);
        int Count();
        void Delete(TEntity t);
        TEntity Get(int id);
        ICollection<TEntity> GetAll();
        TEntity Update(TEntity updated, int key);
    }
    public class BaseManager<TEntity> : IBaseManager<TEntity>
        where TEntity : class
    {
        IGenericRepository<TEntity> _GenericRepository;

        public BaseManager()
        {
            _GenericRepository = new GenericRepository<TEntity>();
        }

        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="id">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        public TEntity Get(int id)
        {
            return _GenericRepository.Get(id);
        }

        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>  
        public ICollection<TEntity> GetAll()
        {
            return _GenericRepository.GetAll().ToList();
        }

        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        public TEntity Add(TEntity t)
        {
            return _GenericRepository.Add(t);
        }

        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="tList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        public IEnumerable<TEntity> AddAll(IEnumerable<TEntity> tList)
        {
            return _GenericRepository.AddAll(tList.ToList()).ToList();
        }

        /// <summary>
        /// Updates a single object based on the provided primary key and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="updated">The updated object to apply to the database</param>
        /// <param name="key">The primary key of the object to update</param>
        /// <returns>The resulting updated object</returns>
        public TEntity Update(TEntity updated, int key)
        {

            return _GenericRepository.Update(updated, key);
        }

        /// <summary>
        /// Deletes a single object from the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The object to delete</param>
        public void Delete(TEntity t)
        {
            _GenericRepository.Delete(t);
        }

        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        public int Count()
        {
            return _GenericRepository.Count();
        }


    }
}