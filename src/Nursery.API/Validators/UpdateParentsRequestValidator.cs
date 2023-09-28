using FluentValidation;
using Nursey.API.Data;
using Nursey.API.Requests;

namespace Nursey.API.Validators;

public class UpdateParentsRequestValidator : AbstractValidator<UpdateParentsRequest>
{
    public UpdateParentsRequestValidator(PersonRepository repository)
    {
        RuleFor(model => model.FatherId)
            .NotEmpty();

        RuleFor(model => model.MotherId)
            .NotEmpty();

        RuleFor(model => model.FatherId)
            .Must(repository.Exists)
            .WithMessage(cpf => $"Father hasnt been registered already. Id: {cpf}");

        RuleFor(model => model.MotherId)
            .Must(repository.Exists)
            .WithMessage(cpf => $"Mother hasnt been registered already. Id: {cpf}");
    }
}