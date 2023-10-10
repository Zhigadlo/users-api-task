using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using users_api.DAL.EF;

namespace users_api.DAL.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected UsersContext _context;

        public RepositoryBase(UsersContext context)
        {
            _context = context;
        }
        public void Create(T entity) => _context.Set<T>().Add(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public virtual IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges ? _context.Set<T>()
                                                                                                         .Where(expression)
                                                                                                         .AsNoTracking() : _context.Set<T>()
                                                                                                         .Where(expression);
        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}