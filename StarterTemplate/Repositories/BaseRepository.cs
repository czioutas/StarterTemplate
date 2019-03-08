using Microsoft.EntityFrameworkCore;
using StarterTemplate.Data;
using StarterTemplate.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StarterTemplate.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext context { get; set; }

        public BaseRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public Task<IEnumerable<T>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindByConditionAync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<T> FirstByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().AsNoTracking().Where(expression).FirstOrDefaultAsync();
        }

        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}