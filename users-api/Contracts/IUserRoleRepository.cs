using Entities;

namespace Contracts
{
    public interface IUserRoleRepository
    {
        IQueryable<UserRole> GetAllUserRoles(bool trackChanges);
        UserRole? GetUserRole(int id, bool trackChanges);
        void CreateUserRole(UserRole userRole);
        void DeleteUserRole(UserRole userRole);
        void UpdateUserRole(UserRole userRole);
    }
}
