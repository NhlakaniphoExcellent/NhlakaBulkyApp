using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhlakaBulky.DataAccess.Repository.IRepository;
using NhlakaBulkyWebApp.Models;

namespace NhlakaBulky.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
        
    }
}
