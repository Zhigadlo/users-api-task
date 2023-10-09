﻿using Contracts;
using Entities;
using users_api.DAL.EF;

namespace users_api.DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(UsersContext context) : base(context)
        {
        }

        public void CreateUser(User user) => Create(user);
        public void DeleteUser(User user) => Delete(user);
        public IEnumerable<User> GetAllUsers(bool trackChanges) => FindAll(trackChanges).OrderBy(x => x.Name).ToList();
        public User? GetUser(int id, bool trackChanges) => FindByCondition(p => p.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}