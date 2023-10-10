using AutoMapper;
using Entities;
using Entities.DataTransferObjects;

namespace users_api.BLL.Mapper
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<RoleForCreationDTO, Role>();
            CreateMap<RoleForUpdateDTO, Role>();
        }
    }
}
