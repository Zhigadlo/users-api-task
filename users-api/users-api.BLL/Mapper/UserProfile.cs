using AutoMapper;
using Entities;
using Entities.DataTransferObjects;

namespace users_api.BLL.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<UserForCreationDTO, User>();
            CreateMap<UserForUpdateDTO, User>();
        }
    }
}
