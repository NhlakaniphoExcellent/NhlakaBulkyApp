using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhlakaBulky.DataAccess.Repository.IRepository;
using NhlakaBulkyWebApp.Models;
using NhlakaWebApp.Models.Models;

namespace NhlakaBulky.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
        
    }
}
