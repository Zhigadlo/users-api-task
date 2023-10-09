using Contracts;
using Entities;
using users_api.DAL.EF;

namespace users_api.DAL.Repositories
{
    public class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(UsersContext context) : base(context)
        {
        }

        public void CreateUserRole(UserRole userRole) => Create(userRole);
        public void DeleteUserRole(UserRole userRole) => Delete(userRole);
        public IEnumerable<UserRole> GetAllUserRoles(bool trackChanges) => FindAll(trackChanges).ToList();
        public UserRole? GetUserRole(int id, bool trackChanges) => FindByCondition(p => p.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}
