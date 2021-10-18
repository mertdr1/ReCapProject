using Core.Entities.Concrete;
using Entities;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            //RuleFor(c => c.Password).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Email).EmailAddress();
        }
    }



}
