using FluentValidation;
using Nursey.API.Repositories;

namespace Nursey.API.Entities;

public class ChildRequestValidator : AbstractValidator<ChildRequest>
{
    public ChildRequestValidator(PersonRepository repository)
    {
        Include(new PersonRequestValidator());

        RuleFor(model => model.CPF)
            .Must(cpf => !repository.Exists(cpf))
            .WithMessage(cpf => $"Child has been registered already. Id: {cpf}");

        RuleFor(model => model.FatherId)
            .Must(repository.Exists)
            .WithMessage(cpf => $"Father hasnt been registered already. Id: {cpf}");

        RuleFor(model => model.MotherId)
            .Must(repository.Exists)
            .WithMessage(cpf => $"Mother hasnt been registered already. Id: {cpf}");
    }
}