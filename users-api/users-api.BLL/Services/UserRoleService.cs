using AutoMapper;
using Contracts.Repository;
using Contracts.Service;
using Entities;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using users_api.BLL.Validation;

namespace users_api.BLL.Services
{
    public class UserRoleService : IUserRoleService
    {
        private IRepositoryManager _repository;
        private IMapper _mapper;
        private UserRoleValidator _validator;
        public UserRoleService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = new UserRoleValidator();
        }

        public UserRoleDTO? Create(UserRoleForCreationDTO item)
        {
            UserRole userRole = _mapper.Map<UserRole>(item);
            var result = _validator.Validate(userRole);
            if (!result.IsValid)
            {
                string message = "";
                result.Errors.ForEach(e => message += e.ErrorMessage);
                throw new EntityIsNotValidException(message);
            }

            _repository.UserRole.CreateUserRole(userRole);
            _repository.Save();
            return _mapper.Map<UserRoleDTO>(userRole);
        }

        public UserRoleDTO? Delete(int id)
        {
            UserRole? userRole = _repository.UserRole.GetUserRole(id, false);
            if (userRole == null)
                throw new NotFoundException($"UserRole with id {id} not found");

            _repository.UserRole.DeleteUserRole(userRole);
            _repository.Save();
            return _mapper.Map<UserRoleDTO>(userRole);
        }

        public UserRoleDTO? Get(int id, bool isTracking = false)
        {
            UserRole? userRole = _repository.UserRole.GetUserRole(id, isTracking);
            return _mapper.Map<UserRoleDTO>(userRole);
        }

        public IEnumerable<UserRoleDTO>? GetAll(bool isTracking = false)
        {
            var users = _repository.UserRole.GetAllUserRoles(isTracking);
            return _mapper.Map<IEnumerable<UserRoleDTO>?>(users);
        }

        public UserRoleDTO? Update(UserRoleForUpdateDTO item)
        {
            UserRole userRole = _mapper.Map<UserRole>(item);
            var result = _validator.Validate(userRole);
            if (!result.IsValid)
            {
                string message = "";
                result.Errors.ForEach(e => message += e.ErrorMessage);
                throw new EntityIsNotValidException(message);
            }

            _repository.UserRole.UpdateUserRole(userRole);
            _repository.Save();
            return _mapper.Map<UserRoleDTO>(userRole);
        }
    }
}
