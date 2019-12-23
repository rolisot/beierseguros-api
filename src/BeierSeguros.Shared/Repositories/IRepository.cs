using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BeierSeguros.Shared.Entities;

namespace BeierSeguros.Shared.Repositories
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task Add(T entity);

        Task<T> GetById(Guid id);

        Task<T> Find(Guid id);

        IQueryable<T> Get();

        IQueryable<T> GetByWhere(Expression<Func<T, bool>> where);

        IQueryable<T> GetByOrderedBy(Expression<Func<T, object>> orderBy);

        IQueryable<T> GetByOrderedByDescending(Expression<Func<T, object>> orderBy);

        IQueryable<T> GetByWhereAndOrderedBy(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy);

        Task<bool> Exists(Expression<Func<T, bool>> condition);

        void Remove(T entity);

        Task Save();

        void Update(T entity);

        Task<int> Count();
    }
}