using FluentValidation;
using Mycar.Common.Extensions;

namespace Mycar.Application.Commands.CreateCarCommand;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(query => query.Car).NotNull();
        RuleFor(query => query.Car.Id).NotEmpty();
        RuleFor(query => query.Car.IdentificationNumber).ValidVin();
        RuleFor(query => query.Car.Brand).NotEmpty();
        RuleFor(query => query.Car.Model).NotEmpty();
        RuleFor(query => query.Car.YearOfProduction).GreaterThan(1900);
        RuleFor(query => query.Car.YearOfRegistration).GreaterThan(1900);
    }
}