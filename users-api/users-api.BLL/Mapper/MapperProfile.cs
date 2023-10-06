using AutoMapper;
using users_api.BLL.DTO;
using users_api.DAL.Models;

namespace users_api.BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>().ForMember(dest => dest.Role,
                                                 opt => opt.MapFrom(src => src.Role.ToString()));
            CreateMap<UserDTO, User>().ForMember(dest => dest.Role,
                                                 opt => opt.MapFrom(src => (Role)Enum.Parse(typeof(Role), src.Role, true)));
        }
    }
}
