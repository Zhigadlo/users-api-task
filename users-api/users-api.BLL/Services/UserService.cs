using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects;
using users_api.BLL.Validation;

namespace users_api.BLL.Services
{
    public class UserService : IService<UserDTO>
    {
        private IRepositoryManager _repository;
        private IMapper _mapper;
        private UserValidator _validator;
        public UserService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = new UserValidator();
        }

        public UserDTO? Create(UserDTO item)
        {
            User user = _mapper.Map<User>(item);
            var result = _validator.Validate(user);
            if (!result.IsValid)
                return null;

            _repository.User.CreateUser(user);
            return item;
        }

        public UserDTO? Delete(int id)
        {
            User? user = _repository.User.GetUser(id, false);
            if (user == null)
                return null;

            _repository.User.DeleteUser(user);
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO? Get(int id, bool isTracking = false)
        {
            User? user = _repository.User.GetUser(id, isTracking);
            return _mapper.Map<UserDTO>(user);
        }

        public IQueryable<UserDTO> GetAll(bool isTracking = false)
        {
            var users = _repository.User.GetAllUsers(isTracking);
            return _mapper.Map<IQueryable<UserDTO>>(users);
        }

        public UserDTO? Update(UserDTO item)
        {
            User user = _mapper.Map<User>(item);
            var result = _validator.Validate(user);
            if (!result.IsValid)
                return null;

            _repository.User.UpdateUser(user);
            return item;
        }
    }
}

