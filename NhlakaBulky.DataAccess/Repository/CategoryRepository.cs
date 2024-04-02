using NhlakaBulky.DataAccess.Repository.IRepository;
using NhlakaBulkyWebApp.Data;
using NhlakaBulkyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhlakaBulky.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDataContext _db;
        public CategoryRepository(ApplicationDataContext db) : base(db) 
        {
            _db = db;
        }
       

        public void Update(Category obj)
        {
           _db.Categories.Update(obj);
        }
    }
}
