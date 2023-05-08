using BusinessLayer.Common;
using BusinessLayer.Dtos;
using FluentValidation;

namespace BusinessLayer.FluentValidation
{
    public class CityValidator : AbstractValidator<CityForCreateDto>
    {
        public CityValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please Provide City Name")
                .Matches(StaticValidation.Alpha).WithMessage("Only Provide Alpha for City Name");

                    
                    
        }
    }
}
