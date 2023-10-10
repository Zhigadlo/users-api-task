﻿namespace Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public List<Role> Roles { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
