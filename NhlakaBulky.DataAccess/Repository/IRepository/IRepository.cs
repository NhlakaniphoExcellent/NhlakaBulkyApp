using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

// THIS IS A GENERIC REPOSITORY !!

namespace NhlakaBulky.DataAccess.Repository.IRepository
{
    // "N" is a generic object on which we want to perform CRUD operations in
    public interface IRepository<N> where N : class
    {
        IEnumerable<N> GetAll();

        // This is equivalent to a FirstOrDefault linq query
        N GetN(Expression<Func<N, bool>> filter);
        void Add(N entity);
        //void Update(N entity);
        void Remove(N entity);

        // This deletes multiple entities in a single coloumn
        // IEnumarable is equivalent to collections
        void RemoveRange(IEnumerable<N> entity);
       
    }
}
