using NhlakaBulky.DataAccess.Repository.IRepository;
using NhlakaBulkyWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlakaBulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDataContext _db;
        public ICategoryRepository categoryRepository { get; private set; }
        public IProductRepository productRepository { get; private set; }
        public UnitOfWork(ApplicationDataContext db) 
        {
            _db = db;
            categoryRepository = new CategoryRepository(_db);
            productRepository = new ProductRepository(_db); 
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
