using FluentValidation;
using Nursey.API.Repositories;

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
            .MinimumLength(3)
            .MaximumLength(100);
    }    
}

public class PersonRequestValidatorSmart : AbstractValidator<PersonRequest>
{
    public PersonRequestValidatorSmart(PersonRepository repository)
    {
        Include(new PersonRequestValidator());

        RuleFor(model => model.CPF)
            .Must(cpf => !repository.Exists(cpf))
            .WithMessage(cpf => $"Parent has been registered already. Id: {cpf}");  
    }
}