using Domain.DTO;
using FluentValidation;
using FluentValidation.Results;

namespace Controller.Validator
{
    public class CustomerRequestDtoValidator : AbstractValidator<CustomerRequestDto>
    {
        public CustomerRequestDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).MinimumLength(1).MaximumLength(50);

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(1).MaximumLength(50);

            RuleFor(x => x.Income).NotEmpty();
            RuleFor(x => x.Income).GreaterThan(0);
            RuleFor(x => x.Income).LessThan(int.MaxValue);
        }

        protected override bool PreValidate(ValidationContext<CustomerRequestDto> context, ValidationResult result)
        {
            if (context.InstanceToValidate is not null)
                return true;
            
            result.Errors.Add(new ValidationFailure("Invalid request", "Payload validation failed"));
            return false;
        }
    }
}