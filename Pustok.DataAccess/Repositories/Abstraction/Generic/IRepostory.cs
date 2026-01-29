using Pustok.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DataAccess.Repositories.Abstraction.Generic
{
    public interface IRepostory<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> GetAll(bool ignoreQueryFilter=false);

        Task<T?> GetByIdAsync(Guid id);

        Task<int> SaveChangesAsync();

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T?> GetAsync(Expression<Func<T, bool>> expression);
    }
}
