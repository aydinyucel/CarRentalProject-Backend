using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotNull();
            RuleFor(u => u.FirstName.Length).GreaterThan(2);
            RuleFor(u => u.LastName).NotNull();
            RuleFor(u => u.LastName.Length).GreaterThan(2);
            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.Email).EmailAddress();
        }
    }
}
