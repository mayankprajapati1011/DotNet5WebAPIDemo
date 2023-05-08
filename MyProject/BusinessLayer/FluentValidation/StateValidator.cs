using BusinessLayer.Dtos;
using FluentValidation;

namespace BusinessLayer.FluentValidation
{
    public class StateValidator : AbstractValidator<StateForCreateDto>
    {
        public StateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please Enter State Name");
            RuleFor(x => x.CountryId).GreaterThan(0).WithMessage("Provide Country Name");
        }
    }
}
