namespace Contracts.Service
{
    public interface IServiceManager
    {
        IUserService User { get; }
        IRoleService Role { get; }
        IUserRoleService UserRole { get; }
    }
}
