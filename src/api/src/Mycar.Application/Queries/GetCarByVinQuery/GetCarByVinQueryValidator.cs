using FluentValidation;

namespace Mycar.Application.Queries.GetCarByVinQuery
{
    public class GetCarByVinQueryValidator : AbstractValidator<GetCarByVinQuery>
    {
        public GetCarByVinQueryValidator()
        {
            RuleFor(query => query.IdentificationNumber).NotEmpty();
        }
    }
}
