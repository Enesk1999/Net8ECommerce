using ETicaret.Model.Models;
using ETicaret.Net8.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Repos
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await values.AsNoTracking().Include(c=>c.Categories).ToListAsync();
        }
    }
}
