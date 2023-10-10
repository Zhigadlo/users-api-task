using Entities;

namespace Contracts.Repository
{
    public interface IRoleRepository
    {
        IQueryable<Role> GetAllRoles(bool trackChanges);
        Role? GetRole(int id, bool trackChanges);
        void CreateRole(Role role);
        void DeleteRole(Role role);
        void UpdateRole(Role role);
    }
}
