﻿namespace users_api.DAL.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
