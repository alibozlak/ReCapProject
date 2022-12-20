using Entities.Concretes;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).GreaterThan(0);
            RuleFor(r => r.CustomerId).GreaterThan(0);
            RuleFor(r => r.RentDate).Length(10);
            RuleFor(r => r.ReturnDate).Length(10);
        }
    }
}
