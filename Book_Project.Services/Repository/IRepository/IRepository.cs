using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book_Project.Services.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Remove(int id);
        //IEnumerable return collection of data in the form of list
        //it is a generic interface which allows looping over generic or non-generic list.
        void RemoveRange(IEnumerable<T> entities);
        T Get(int id);
        //IEnumerable is a generic interface that represents a read only collection of elements.
        // from Expression<Func<T,bool>> this is a lambda expression that takes an object of type 'T' and return boolean value  whether  that object should be include in the result sets ornot.
        //Iqueryable is used to return an ordered version of list or allows a specify sorting criteria for the query results.
        // it allows us to specify related entities to include in the query results.it is a string representing a comma-separated list of navigation properties to be included in the query results.
        // Summary is that this method allows us to retrieve a sequence of object of type 'T' form a data source, optionally applying a filter, specifing ordering
        //and include related entites in the results.it provides flexibility in querying and retrieving data.
        IEnumerable<T> GetAll(Expression<Func<T,bool>>filter=null,
           Func<IQueryable<T>,IOrderedQueryable<T>>orderBy= null,
           string includeproperties=null);
        // FirstOrDefault returns the first element of a sequence that satisfies a specified condition or a default value if no such element is found. 
        //this method retrieves the first element of type 'T' form a data source that satisfies the specified filter condition,or it returns a default values for 'T' if no such element is found.Additionally, it allows you to include related entities in the query results if needed
        T FirstorDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        void Save();
    }
}
