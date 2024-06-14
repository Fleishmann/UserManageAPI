using FluentValidation;
using UserManageAPI.Models;

namespace UserManageAPI.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Nome).NotEmpty();
            RuleFor(user => user.Email).NotEmpty().EmailAddress();
            RuleFor(user => user.Password).NotEmpty().MinimumLength(6);
        }
    }
}