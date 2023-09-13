using FluentValidation;
using Mycar.Common.Extensions;

namespace Mycar.Application.Commands.DeleteCarCommand
{
    public class DeleteCarCommandValidator : AbstractValidator<DeleteCarCommand>
    {
        public DeleteCarCommandValidator()
        {
            RuleFor(query => query.Vin).ValidVIN();
        }
    }
}
