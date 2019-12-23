using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BeierSeguros.Infra.Data;
using BeierSeguros.Shared.Entities;
using BeierSeguros.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BeierSeguros.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>()
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<T> Find(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetByWhere(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>()
                .Where(where).AsNoTracking();
        }

        public IQueryable<T> GetByOrderedBy(Expression<Func<T, object>> orderBy)
        {
            return _context.Set<T>()
                 .AsNoTracking()
                 .OrderBy(orderBy);
        }

        public IQueryable<T> GetByOrderedByDescending(Expression<Func<T, object>> orderBy)
        {
            return _context.Set<T>()
                .AsNoTracking()
                .OrderByDescending(orderBy);
        }

        public IQueryable<T> GetByWhereAndOrderedBy(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy)
        {

            return _context.Set<T>()
                .Where(where)
                .AsNoTracking()
                .OrderBy(orderBy);
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> condition)
        {
            return await _context.Set<T>().AnyAsync(condition);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task<int> Count()
        {
            return await _context.Set<T>().CountAsync();
        }

        public void Dispose()
        {
            _context.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}