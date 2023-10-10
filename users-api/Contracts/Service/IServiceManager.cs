using Entities.DataTransferObjects;

namespace Contracts.Service
{
    public interface IServiceManager
    {
        IService<UserDTO, UserForCreationDTO, UserForUpdateDTO> User { get; }
        IService<RoleDTO, RoleForCreationDTO, RoleForUpdateDTO> Role { get; }
        IService<UserRoleDTO, UserRoleForCreationDTO, UserRoleForUpdateDTO> UserRole { get; }
    }
}
