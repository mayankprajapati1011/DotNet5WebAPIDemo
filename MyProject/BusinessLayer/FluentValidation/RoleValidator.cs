using BusinessLayer.Dtos;
using FluentValidation;

namespace BusinessLayer.FluentValidation
{
    public class RoleValidator : AbstractValidator<RoleForCreateDto>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please Enter Role Name");
        }
    }
}
