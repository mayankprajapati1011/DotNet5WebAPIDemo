using BusinessLayer.Common;
using BusinessLayer.Dtos;
using FluentValidation;

namespace BusinessLayer.FluentValidation
{
    public class UserValidator : AbstractValidator<UserForCreateDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Please Provide Full Name")
                .Matches(StaticValidation.Alpha).WithMessage("Only Provide Alpha for Full Name");
                
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please Provide Password");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Please Provide e-Mail Id")
                .Matches(StaticValidation.Email).WithMessage("Provide Valid e-Mail Id");

            RuleFor(x => x.MobileNo).NotEmpty().WithMessage("Please Provide Mobile No")
                .Matches(StaticValidation.Numeric).WithMessage("Only Provide Numeric for Mobile No")
            .MaximumLength(10).WithMessage("Mobile No Length 10 Digits");

            RuleFor(x => x.RoleId).GreaterThan(0).WithMessage("Provide Valid for Role");
               

        }
    }
}
