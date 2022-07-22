using FluentValidation;
using User.Domain.DTO;

namespace User.WebAPI.Validators
{
    public class UpdateUserValidator:AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Age).GreaterThan(0);
            RuleFor(x => x.DepartmentId).GreaterThan(0).LessThan(10);


        }
    }
}
