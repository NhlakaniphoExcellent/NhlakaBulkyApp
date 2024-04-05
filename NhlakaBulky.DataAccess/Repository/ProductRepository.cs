using NhlakaBulky.DataAccess.Repository.IRepository;
using NhlakaBulkyWebApp.Data;
using NhlakaBulkyWebApp.Models;
using NhlakaWebApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhlakaBulky.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDataContext _db;
        public ProductRepository(ApplicationDataContext db) : base(db) 
        {
            _db = db;
        }
       

        public void Update(Product obj)
        {
           _db.Products.Update(obj);
        }
    }
}
