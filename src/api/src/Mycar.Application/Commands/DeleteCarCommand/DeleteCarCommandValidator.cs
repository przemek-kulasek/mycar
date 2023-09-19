using FluentValidation;

namespace Mycar.Application.Commands.DeleteCarCommand;

public class DeleteCarCommandValidator : AbstractValidator<DeleteCarCommand>
{
    public DeleteCarCommandValidator()
    {
        RuleFor(query => query.Id).NotEmpty();
    }
}