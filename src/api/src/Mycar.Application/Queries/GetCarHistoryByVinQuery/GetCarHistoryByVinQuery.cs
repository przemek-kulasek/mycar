using MediatR;
using Mycar.Application.Dtos;

namespace Mycar.Application.Queries.GetCarHistoryByVinQuery
{
    public class GetCarHistoryByVinQuery : IRequest<CarHistoryDto>
    {
        public required string Vin { get; set; }
    }
}
