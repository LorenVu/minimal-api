using FluentValidation;

namespace MinimalApi.Application.Features.Commands.UpdateCustomer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .MaximumLength(50).WithMessage("{PropertyName} cannot be more than 50 characters");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty");

        RuleFor(x => x.EmailAddress)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
    }
}