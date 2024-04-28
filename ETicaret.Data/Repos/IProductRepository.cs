using ETicaret.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Repos
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProduct();
        
    }
}
