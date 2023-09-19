using FluentValidation;

namespace Mycar.Application.Queries.GetOperationsByCarIdQuery;

public class GetOperationsByCarIdQueryValidator : AbstractValidator<GetOperationsByCarIdQuery>
{
    public GetOperationsByCarIdQueryValidator()
    {
        RuleFor(query => query.CarId).NotEmpty();
    }
}