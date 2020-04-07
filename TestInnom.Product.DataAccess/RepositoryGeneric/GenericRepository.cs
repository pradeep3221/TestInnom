using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestInnom.Product.DataModels.Models;

namespace TestInnom.Product.DataAccess
{

    public interface IGenericRepository<TObject> where TObject : class
    {
        TObject Add(TObject t);
        global::System.Collections.Generic.IEnumerable<TObject> AddAll(global::System.Collections.Generic.IEnumerable<TObject> tList);
        int Count();
        void Delete(TObject t);
        TObject Get(int id);
        global::System.Collections.Generic.ICollection<TObject> GetAll();
        TObject Update(TObject updated, int key);
    }
    public class GenericRepository<TObject> : IGenericRepository<TObject> where TObject : class
    {
        protected TestInnomDBContext _context;

        ///// <summary>
        ///// The contructor requires an open DataContext to work with
        ///// </summary>
        ///// <param name="context">An open DataContext</param>
        //public GenericRepository(TestInnomContext context)
        //{
        //    _context = context;
        //}
        public GenericRepository()
        {
            _context = new TestInnomDBContext();
        }

        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="id">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        public TObject Get(int id)
        {
            return _context.Set<TObject>().Find(id);
        }

        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>
        public ICollection<TObject> GetAll()
        {
            return _context.Set<TObject>().ToList();
        }

        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        public TObject Add(TObject t)
        {
            _context.Set<TObject>().Add(t);
            _context.SaveChanges();
            return t;
        }

        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="t">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        public async Task<TObject> AddAsync(TObject t)
        {
            _context.Set<TObject>().Add(t);
            await _context.SaveChangesAsync();
            return t;
        }

        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="tList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        public IEnumerable<TObject> AddAll(IEnumerable<TObject> tList)
        {
            _context.Set<TObject>().AddRange(tList);
            _context.SaveChanges();
            return tList;
        }

        /// <summary>
        /// Updates a single object based on the provided primary key and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="updated">The updated object to apply to the database</param>
        /// <param name="key">The primary key of the object to update</param>
        /// <returns>The resulting updated object</returns>
        public TObject Update(TObject updated, int key)
        {
            if (updated == null)
                return null;

            TObject existing = _context.Set<TObject>().Find(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
                _context.SaveChanges();
            }
            return existing;
        }


        /// <summary>
        /// Deletes a single object from the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The object to delete</param>
        public void Delete(TObject t)
        {
            _context.Set<TObject>().Remove(t);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        public int Count()
        {
            return _context.Set<TObject>().Count();
        }

        //Usage
        //Include the BaseService.cs class in your application and set the appropriate namespace.
        //Inherit from BaseService in your Service classes and initialize the constructor and base constructor with a data context.
        //public class CategoryService : BaseService<Category>
        //{
        //    public CategoryService(MyDataContext context)
        //        : base(context)
        //    { }
        //}
        //Overrides
        //Override the base methods as needed by declaring the same method as new

        //public new async Task<Category> GetAsync(int id)
        //{
        //    return await _context.Categories.SingleOrDefaultAsync(x => x.categoryID == id);
        //}
    }

}