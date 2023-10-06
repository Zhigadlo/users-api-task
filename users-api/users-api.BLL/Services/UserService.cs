using AutoMapper;
using Microsoft.EntityFrameworkCore;
using users_api.BLL.DTO;
using users_api.BLL.Validation;
using users_api.DAL.EF;
using users_api.DAL.Models;

namespace users_api.BLL.Services
{
    public class UserService
    {
        private UsersContext _context;
        private IMapper _mapper;
        private UserValidator _validator;
        public UserService(UsersContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _validator = new UserValidator();
        }

        public async Task<UserDTO?> CreateAsync(UserDTO item)
        {
            User user = _mapper.Map<User>(item);
            var result = _validator.Validate(user);
            if (!result.IsValid)
                return null;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<UserDTO?> DeleteAsync(Guid id)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return null;

            var userDTO = _mapper.Map<UserDTO>(user);

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
            return userDTO;
        }

        public async Task<UserDTO?> GetAsync(Guid id, bool isTracking = true)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetAll(bool isTracking = true)
        {
            var users = _context.Users;
            if (!isTracking)
                return _mapper.Map<IEnumerable<UserDTO>>(users.AsNoTracking());

            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO?> UpdateAsync(UserDTO item)
        {
            User user = _mapper.Map<User>(item);
            var result = _validator.Validate(user);
            if (!result.IsValid)
                return null;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}

