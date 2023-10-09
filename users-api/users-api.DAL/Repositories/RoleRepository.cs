using Contracts;
using Entities;
using users_api.DAL.EF;

namespace users_api.DAL.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(UsersContext context) : base(context)
        {
        }

        public void CreateRole(Role role) => Create(role);
        public void DeleteRole(Role role) => Delete(role);
        public IEnumerable<Role> GetAllRoles(bool trackChanges) => FindAll(trackChanges).OrderBy(x => x.Name).ToList();
        public Role? GetRole(int id, bool trackChanges) => FindByCondition(p => p.Id.Equals(id), trackChanges).SingleOrDefault();
        public void UpdateRole(Role role) => Update(role);
    }
}
