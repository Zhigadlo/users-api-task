using Entities.DataTransferObjects;

namespace Contracts
{
    public interface IServiceManager
    {
        IService<UserDTO> User { get; }
        IService<RoleDTO> Role { get; }
        IService<UserRoleDTO> UserRole { get; }
        void Save();
    }
}
