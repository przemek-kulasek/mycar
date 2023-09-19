using FluentValidation;
using Mycar.Common.Extensions;

namespace Mycar.Application.Queries.GetCarHistoryByVinQuery;

public class GetCarHistoryByVinQueryValidator : AbstractValidator<GetCarHistoryByVinQuery>
{
    public GetCarHistoryByVinQueryValidator()
    {
        RuleFor(query => query.Vin).ValidVin();
    }
}