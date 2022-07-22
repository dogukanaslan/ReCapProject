using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Descriptions).MinimumLength(2);
            //RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(1500);
        }
    }
}
