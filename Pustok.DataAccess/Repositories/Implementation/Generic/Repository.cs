using Microsoft.EntityFrameworkCore;
using Pustok.Core.Entities.Common;
using Pustok.DataAccess.Contexts;
using Pustok.DataAccess.Repositories.Abstraction.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DataAccess.Repositories.Implementation.Generic
{
    internal class Repository<T>(AppDbContext _context) : IRepostory<T> where T : BaseEntity
    {
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await _context.Set<T>().AnyAsync(expression);

            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(expression);

            return entity;
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var result = await _context.Set<T>().FindAsync(id);

            return result;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
