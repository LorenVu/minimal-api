using FluentValidation;

namespace MinimalApi.Application.Features.Commands.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .MaximumLength(50).WithMessage("{PropertyName} cannot be more than 50 characters");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty");

        RuleFor(x => x.EmailAddress)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty");
    }
}