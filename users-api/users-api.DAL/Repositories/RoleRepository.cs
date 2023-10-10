using Contracts.Repository;
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
        public IQueryable<Role> GetAllRoles(bool trackChanges) => FindAll(trackChanges).OrderBy(x => x.Name).AsQueryable();
        public Role? GetRole(int id, bool trackChanges) => FindByCondition(p => p.Id.Equals(id), trackChanges).SingleOrDefault();
        public void UpdateRole(Role role) => Update(role);
    }
}
