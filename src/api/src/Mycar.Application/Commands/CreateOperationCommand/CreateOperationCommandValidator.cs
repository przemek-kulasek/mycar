using FluentValidation;

namespace Mycar.Application.Commands.CreateOperationCommand
{
    public class CreateOperationCommandValidator : AbstractValidator<CreateOperationCommand>
    {
        public CreateOperationCommandValidator() 
        {
            RuleFor(query => query.CarId).NotEmpty();
            RuleFor(query => query.Operation).NotNull();
            RuleFor(query => query.Operation.Id).NotEmpty();
            RuleFor(query => query.Operation.CarId).NotEmpty();
            RuleFor(query => query.Operation.OperationType).IsInEnum();
            RuleFor(query => query.Operation.Mileage).GreaterThan(0);
            RuleFor(query => query.Operation.Description).NotEmpty();
        }
    }
}
