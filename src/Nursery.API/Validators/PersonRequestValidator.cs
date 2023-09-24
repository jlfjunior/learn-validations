using FluentValidation;
using Nursey.API.Requests;

namespace Nursey.API.Validators;

public class PersonRequestValidator : AbstractValidator<PersonRequest>
{
    public PersonRequestValidator()
    {
        RuleFor(model => model.CPF)
            .NotEmpty()
            .Length(11);

        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(model => model.Address)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);
    }    
}