using FluentValidation;
using users_api.DAL.Models;

namespace users_api.BLL.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name).NotEmpty();
            RuleFor(u => u.Age).Must(a => a > 0);
            RuleFor(u => u.Role).NotNull().IsInEnum();
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
        }
    }
}
