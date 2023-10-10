using Contracts.Repository;
using users_api.DAL.EF;
using users_api.DAL.Repositories;

namespace users_api.DAL.Managers
{
    public class RepositoryManager : IRepositoryManager
    {
        private UsersContext _context;
        private IUserRepository? _userRepository;
        private IRoleRepository? _roleRepository;
        private IUserRoleRepository? _userRoleRepository;
        public RepositoryManager(UsersContext context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);

                return _userRepository;
            }
        }

        public IUserRoleRepository UserRole
        {
            get
            {
                if (_userRoleRepository == null)
                    _userRoleRepository = new UserRoleRepository(_context);

                return _userRoleRepository;
            }
        }

        public IRoleRepository Role
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepository(_context);

                return _roleRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
