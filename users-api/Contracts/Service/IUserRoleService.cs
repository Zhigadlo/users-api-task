using Entities.DataTransferObjects;

namespace Contracts.Service
{
    public interface IUserRoleService
    {
        UserRoleDTO? Create(UserRoleForCreationDTO entity);
        UserRoleDTO? Delete(int id);
        IEnumerable<UserRoleDTO>? GetAll(bool trackChanges);
        UserRoleDTO? Get(int id, bool trackChanges);
        UserRoleDTO? Update(UserRoleForUpdateDTO entity);
    }
}
