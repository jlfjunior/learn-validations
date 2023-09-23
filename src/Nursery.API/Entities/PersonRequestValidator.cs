using FluentValidation;

namespace Nursey.API.Entities;

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
            .MinimumLength(10)
            .MaximumLength(100);
    }    
}