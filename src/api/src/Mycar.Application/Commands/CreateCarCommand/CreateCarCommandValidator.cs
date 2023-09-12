using FluentValidation;
using Mycar.Application.Queries.GetCarByVinQuery;

namespace Mycar.Application.Commands.CreateCarCommand
{
    public class CreateCarCommandValidator : AbstractValidator<GetCarByVinQuery>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(query => query.IdentificationNumber).NotEmpty();
        }
    }
}
