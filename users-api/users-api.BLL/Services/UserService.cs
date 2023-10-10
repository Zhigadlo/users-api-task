using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects;
using users_api.BLL.Validation;

namespace users_api.BLL.Services
{
    public class UserService : IService<UserDTO, UserForCreationDTO, UserForUpdateDTO>
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

        public UserDTO? Create(UserForCreationDTO item)
        {
            User user = _mapper.Map<User>(item);
            var result = _validator.Validate(user);
            if (!result.IsValid)
                return null;

            _repository.User.CreateUser(user);
            _repository.Save();
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO? Delete(int id)
        {
            User? user = _repository.User.GetUser(id, false);
            if (user == null)
                return null;

            _repository.User.DeleteUser(user);
            _repository.Save();
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO? Get(int id, bool isTracking = false)
        {
            User? user = _repository.User.GetUser(id, isTracking);
            return _mapper.Map<UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetAll(bool isTracking = false)
        {
            var users = _repository.User.GetAllUsers(isTracking);
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public UserDTO? Update(UserForUpdateDTO item)
        {
            User user = _mapper.Map<User>(item);
            var result = _validator.Validate(user);
            if (!result.IsValid)
                return null;

            _repository.User.UpdateUser(user);
            _repository.Save();
            return _mapper.Map<UserDTO>(user);
        }
    }
}

