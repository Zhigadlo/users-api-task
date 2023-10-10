using AutoMapper;
using Entities;
using Entities.DataTransferObjects;

namespace users_api.BLL.Mapper
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRole, UserRoleDTO>().ReverseMap();
            CreateMap<UserRoleForCreationDTO, UserRole>();
            CreateMap<UserRoleForUpdateDTO, UserRole>();
        }
    }
}
