﻿using Entities.Concretes;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.UserId).GreaterThan(0);
            RuleFor(c => c.CompanyName).MinimumLength(2);
        }
    }
}