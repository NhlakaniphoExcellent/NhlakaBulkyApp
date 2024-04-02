using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NhlakaBulky.DataAccess.Repository.IRepository;
using NhlakaBulkyWebApp.Data;

namespace NhlakaBulky.DataAccess.Repository
{
    // Dependency injection is basically accessing the DbClass or "database" using _db
    public class Repository<N> : IRepository<N> where N : class
    {
        private readonly ApplicationDataContext _db;
        internal DbSet<N> dbSet;
        public Repository(ApplicationDataContext db)
        {
            _db = db;
            // dbSet is basically equivalent to _db.Categories
            this.dbSet = _db.Set<N>();
        }

        public void Add(N entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<N> GetAll()
        {
            IQueryable<N> query = dbSet;
            return query.ToList();
        }

        public N GetN(Expression<Func<N, bool>> filter)
        {
            IQueryable<N> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(N entity)
        {
            IQueryable<N> query = dbSet;
            dbSet.Remove(entity);
        }

        // This deletes multiple entities in a single coloumn
        public void RemoveRange(IEnumerable<N> entity)
        {
            IQueryable<N> query = dbSet;
            dbSet.RemoveRange(entity);
        }
    }
}
