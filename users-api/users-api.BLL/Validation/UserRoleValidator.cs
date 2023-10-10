using Entities;
using FluentValidation;

namespace users_api.BLL.Validation
{
    public class UserRoleValidator : AbstractValidator<UserRole>
    {
        public UserRoleValidator()
        {
            RuleFor(u => u.RoleId).NotEmpty();
            RuleFor(u => u.UserId).NotEmpty();
        }
    }
}
