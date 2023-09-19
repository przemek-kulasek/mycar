using FluentValidation;

namespace Mycar.Application.Queries.GetItemsByOperationIdQuery;

public class GetItemsByOperationIdQueryValidator : AbstractValidator<GetItemsByOperationIdQuery>
{
    public GetItemsByOperationIdQueryValidator()
    {
        RuleFor(query => query.CarId).NotEmpty();
        RuleFor(query => query.OperationId).NotEmpty();
    }
}