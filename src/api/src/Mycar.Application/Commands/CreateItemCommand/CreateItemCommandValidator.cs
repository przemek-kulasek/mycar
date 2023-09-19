using FluentValidation;

namespace Mycar.Application.Commands.CreateItemCommand;

public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
{
    public CreateItemCommandValidator()
    {
        RuleFor(query => query.CarId).NotEmpty();
        RuleFor(query => query.OperationId).NotEmpty();
        RuleFor(query => query.Item).NotNull();
        RuleFor(query => query.Item.Id).NotEmpty();
        RuleFor(query => query.Item.OperationId).NotEmpty();
        RuleFor(query => query.Item.ItemType).IsInEnum();
        RuleFor(query => query.Item.Description).NotEmpty();
    }
}