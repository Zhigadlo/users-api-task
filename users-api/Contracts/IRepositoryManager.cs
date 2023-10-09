namespace Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IRoleRepository Role { get; }
        IUserRoleRepository UserRole { get; }
        void Save();
    }
}
