using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using users_api.DAL.EF;

namespace users_api.DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(UsersContext context) : base(context)
        {
        }

        public void CreateUser(User user) => Create(user);
        public void DeleteUser(User user) => Delete(user);
        public IQueryable<User> GetAllUsers(bool trackChanges) => FindAll(trackChanges).OrderBy(x => x.Name).AsQueryable();
        public User? GetUser(int id, bool trackChanges) => FindByCondition(p => p.Id.Equals(id), trackChanges).SingleOrDefault();
        public void UpdateUser(User user) => Update(user);

        public override IQueryable<User> FindAll(bool trackChanges)
        {
            var users = _context.Users.Include(u => u.Roles);
            return trackChanges ? users.AsNoTracking() : users;
        }
        public override IQueryable<User> FindByCondition(Expression<Func<User, bool>> expression, bool trackChanges)
        {
            return _context.Users.Include(u => u.Roles).Where(expression);
        }
    }
}
