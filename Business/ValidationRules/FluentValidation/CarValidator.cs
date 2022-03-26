using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotNull();
            RuleFor(c => c.BrandId).GreaterThanOrEqualTo(0);
            RuleFor(c => c.ColorId).NotNull();
            RuleFor(c => c.ColorId).GreaterThanOrEqualTo(0);
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelYear).LessThanOrEqualTo((short)DateTime.Now.Year);
            RuleFor(c => c.DailyPrice).NotNull();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description.Length).GreaterThan(2).WithMessage("Model Adı 2 Karakterden Uzun Olmalı!");
        }


    }
}
