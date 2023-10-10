using AutoMapper;
using Contracts.Repository;
using Contracts.Service;
using users_api.BLL.Services;

namespace users_api.BLL.Managers
{
    public class ServiceManager : IServiceManager
    {
        private IUserService? _userService;
        private IRoleService? _roleService;
        private IUserRoleService? _userRoleService;

        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IUserService User
        {
            get
            {
                if (_userService == null)
                    _userService = new UserService(_repositoryManager, _mapper);

                return _userService;
            }
        }

        public IRoleService Role
        {
            get
            {
                if (_roleService == null)
                    _roleService = new RoleService(_repositoryManager, _mapper);

                return _roleService;
            }
        }

        public IUserRoleService UserRole
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
