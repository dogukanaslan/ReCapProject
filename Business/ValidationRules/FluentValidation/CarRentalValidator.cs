﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarRentalValidator:AbstractValidator<CarRental>
    {
        public CarRentalValidator()
        {
            RuleFor(cr => cr.RentDate).NotEmpty();
            RuleFor(cr => cr.ReturnDate).NotEmpty();
        }
    }
}
