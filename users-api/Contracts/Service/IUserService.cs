using Entities.DataTransferObjects;
using Entities.FilterModels;
using Entities.Pagination;

namespace Contracts.Service
{
    public interface IUserService
    {
        UserDTO? Create(UserForCreationDTO entity);
        UserDTO? Delete(int id);
        IEnumerable<UserDTO>? GetAll(bool trackChanges);
        UserDTO? Get(int id, bool trackChanges);
        UserDTO? Update(UserForUpdateDTO entity);
        IEnumerable<UserDTO>? GetPage(PaginationModel paginationModel, UserFilterModel filterModel);
    }
}
