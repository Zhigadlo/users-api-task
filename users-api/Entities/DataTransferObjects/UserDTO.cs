namespace Entities.DataTransferObjects
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public RoleDTO[] Roles { get; set; }
    }
}
