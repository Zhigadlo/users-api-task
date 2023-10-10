using AutoMapper;
using Contracts.Repository;
using Contracts.Service;
using Entities;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.FilterModels;
using Entities.Pagination;
using Microsoft.EntityFrameworkCore;
using users_api.BLL.Validation;

namespace users_api.BLL.Services
{
    public class UserService : IUserService
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
            {
                string message = "";
                result.Errors.ForEach(e => message += e.ErrorMessage);
                throw new EntityIsNotValidException(message);
            }

            _repository.User.CreateUser(user);
            try
            {
                _repository.Save();
            }
            catch (DbUpdateException)
            {
                throw new EmailIsNotUniqueException();
            }

            _repository.Save();
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO? Delete(int id)
        {
            User? user = _repository.User.GetUser(id, false);
            if (user == null)
                throw new NotFoundException($"User with id {id} not found");

            _repository.User.DeleteUser(user);
            _repository.Save();
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO? Get(int id, bool isTracking = false)
        {
            User? user = _repository.User.GetUser(id, isTracking);
            return _mapper.Map<UserDTO>(user);
        }

        public IEnumerable<UserDTO>? GetAll(bool isTracking = false)
        {
            var users = _repository.User.GetAllUsers(isTracking);
            return _mapper.Map<IEnumerable<UserDTO>?>(users);
        }

        public IEnumerable<UserDTO> GetPage(PaginationModel paginationModel, UserFilterModel filterModel)
        {
            IQueryable<User>? users = _repository.User.GetAllUsers(false);

            users = UserFilter(filterModel, users);
            users = UserSort(filterModel.SortType, users);
            users = UserPagination(paginationModel, users);
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public UserDTO? Update(UserForUpdateDTO item)
        {
            User user = _mapper.Map<User>(item);
            var result = _validator.Validate(user);
            if (!result.IsValid)
            {
                string message = "";
                result.Errors.ForEach(e => message += e.ErrorMessage);
                throw new EntityIsNotValidException(message);
            }

            _repository.User.UpdateUser(user);
            _repository.Save();
            return _mapper.Map<UserDTO>(user);
        }

        private IQueryable<User> UserFilter(UserFilterModel filterModel, IQueryable<User> users)
        {
            users = users.Where(u => u.Name.Contains(filterModel.Name))
                         .Where(u => u.Email.Contains(filterModel.Email));

            if (filterModel.AgeIsValid())
                users = users.Where(u => u.Age <= filterModel.MaxAge)
                             .Where(u => u.Age >= filterModel.MinAge);

            return users;
        }

        private IQueryable<User> UserSort(string sortType, IQueryable<User> users)
        {
            switch (sortType)
            {
                case "name_asc":
                    users = users.OrderBy(u => u.Name);
                    break;
                case "name_desc":
                    users = users.OrderByDescending(u => u.Name);
                    break;
                case "age_asc":
                    users = users.OrderBy(u => u.Age);
                    break;
                case "age_desc":
                    users = users.OrderByDescending(u => u.Age);
                    break;
                case "email_asc":
                    users = users.OrderBy(u => u.Email);
                    break;
                case "email_desc":
                    users = users.OrderByDescending(u => u.Email);
                    break;
                default:
                    users.OrderBy(u => u.Name);
                    break;
            }

            return users;
        }

        private IQueryable<User> UserPagination(PaginationModel paginationModel, IQueryable<User> users)
        {
            int totalPages = (int)Math.Ceiling(users.Count() / (double)paginationModel.PageSize);
            if (paginationModel.PageNumber > totalPages)
                paginationModel.PageNumber = 1;
            return users.Skip((paginationModel.PageNumber - 1) * paginationModel.PageSize).Take(paginationModel.PageSize);
        }
    }
}

