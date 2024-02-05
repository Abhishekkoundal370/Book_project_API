using Book_Project.Services.Data;
using Book_Project.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book_Project.Services.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //enties means classes 
        // This code sets a repository class (Rpository<T>) that is responsible for interacting with entities of type 'T' within the application database using entity frameworkcore.
        //it initialize a database context(context) and a 'DbSet<T>' to facilitates database operations on the specified entity type.
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context= context;
            dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
           dbSet.Add(entity);
            Save();
        }

        public T FirstorDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (includeProperties != null)
                foreach(var includeProp in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            return query.FirstOrDefault();
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeproperties = null)
        {
            IQueryable<T> query = dbSet;
            if(filter !=null)
                query=query.Where(filter);
            if(includeproperties !=null)
            {
                foreach (var includeProp in includeproperties.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);

                }
                if (orderBy != null)
                    return orderBy(query);
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
           dbSet.Remove(entity);
            Save();

        }

        public void Remove(int id)
        {
            var entity = Get(id);
            Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
           Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            Save();
        }
    }
}
