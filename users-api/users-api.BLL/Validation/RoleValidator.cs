using Entities;
using FluentValidation;

namespace users_api.BLL.Validation
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
        }
    }
}
