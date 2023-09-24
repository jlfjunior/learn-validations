using FluentValidation;
using Nursey.API.Data;
using Nursey.API.Requests;

namespace Nursey.API.Validators;

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