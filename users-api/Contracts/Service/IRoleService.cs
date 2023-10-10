using Entities.DataTransferObjects;

namespace Contracts.Service
{
    public interface IRoleService
    {
        RoleDTO? Create(RoleForCreationDTO entity);
        RoleDTO? Delete(int id);
        IEnumerable<RoleDTO>? GetAll(bool trackChanges);
        RoleDTO? Get(int id, bool trackChanges);
        RoleDTO? Update(RoleForUpdateDTO entity);
    }
}
