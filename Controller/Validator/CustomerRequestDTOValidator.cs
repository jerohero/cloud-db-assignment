using BMH.Domain.DTO;
using FluentValidation;
using FluentValidation.Results;

namespace BMH.Validators
{
    public class CustomerRequestDTOValidator : AbstractValidator<CustomerRequestDTO>
    {
        public CustomerRequestDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).MinimumLength(1).MaximumLength(50);

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(1).MaximumLength(50);

            RuleFor(x => x.Income).NotEmpty();
            RuleFor(x => x.Income).GreaterThan(0);
            RuleFor(x => x.Income).LessThan(decimal.MaxValue);
        }

        protected override bool PreValidate(ValidationContext<CustomerRequestDTO> context, ValidationResult result)
        {
            if (context.InstanceToValidate is null)
            {
                result.Errors.Add(new ValidationFailure("Invalid request", "Payload validation failed"));

                return false;
            }
            return true;
        }
    }
}