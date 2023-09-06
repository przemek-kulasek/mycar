using MediatR;
using Mycar.Application.Dtos;

namespace Mycar.Application.Queries.GetCarByVinQuery
{
    public class GetCarByVinQueryHandler : IRequestHandler<GetCarByVinQuery, CarDto>
    {
        public Task<CarDto> Handle(GetCarByVinQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
