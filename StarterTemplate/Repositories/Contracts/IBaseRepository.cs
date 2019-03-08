using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StarterTemplate.Repositories.Contracts
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> FindAllAsync();

        Task<IEnumerable<T>> FindByConditionAync(Expression<Func<T, bool>> expression);

        Task<T> FirstByConditionAsync(Expression<Func<T, bool>> expression);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task SaveAsync();
    }
}