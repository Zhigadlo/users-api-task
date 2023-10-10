using AutoMapper;
using Contracts.Repository;
using Contracts.Service;
using Entities.DataTransferObjects;
using users_api.BLL.Services;

namespace users_api.BLL.Managers
{
    public class ServiceManager : IServiceManager
    {
        private IService<UserDTO, UserForCreationDTO, UserForUpdateDTO>? _userService;
        private IService<RoleDTO, RoleForCreationDTO, RoleForUpdateDTO>? _roleService;
        private IService<UserRoleDTO, UserRoleForCreationDTO, UserRoleForUpdateDTO>? _userRoleService;

        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IService<UserDTO, UserForCreationDTO, UserForUpdateDTO> User
        {
            get
            {
                if (_userService == null)
                    _userService = new UserService(_repositoryManager, _mapper);

                return _userService;
            }
        }

        public IService<RoleDTO, RoleForCreationDTO, RoleForUpdateDTO> Role
        {
            get
            {
                if (_roleService == null)
                    _roleService = new RoleService(_repositoryManager, _mapper);

                return _roleService;
            }
        }

        public IService<UserRoleDTO, UserRoleForCreationDTO, UserRoleForUpdateDTO> UserRole
        {
            get
            {
                if (_userRoleService == null)
                    _userRoleService = new UserRoleService(_repositoryManager, _mapper);

                return _userRoleService;
            }
        }
    }
}
