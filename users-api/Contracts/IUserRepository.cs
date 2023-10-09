using Entities;

namespace Contracts
{
    public interface IUserRepository
    {
        IQueryable<User> GetAllUsers(bool trackChanges);
        User? GetUser(int id, bool trackChanges);
        void CreateUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
    }
}
