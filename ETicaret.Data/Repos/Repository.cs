using ETicaret.Net8.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Repos
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        internal DbSet<T> values;
        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            values = context.Set<T>();  //context.Categories, context.Products ==values
        }

        

        public async Task AddAsync(T entity)
        {
             await values.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await values.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await values.FirstOrDefaultAsync(expression);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            values.RemoveRange(entity);
        }

        public void Remove(T entity)
        {
            values.Remove(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            values.Update(entity);
        }
    }
}
