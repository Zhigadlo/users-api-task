using Entities;

namespace Contracts
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAllRoles(bool trackChanges);
        Role? GetRole(int id, bool trackChanges);
        void CreateRole(Role role);
        void DeleteRole(Role role);
    }
}
