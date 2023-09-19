using FluentValidation;
using Mycar.Common.Extensions;

namespace Mycar.Application.Queries.GetCarByVinQuery;

public class GetCarByVinQueryValidator : AbstractValidator<GetCarByVinQuery>
{
    public GetCarByVinQueryValidator()
    {
        RuleFor(query => query.IdentificationNumber).ValidVin();
    }
}