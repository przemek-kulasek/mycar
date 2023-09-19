using MediatR;
using Mycar.Application.Dtos;

namespace Mycar.Application.Queries.GetCarByVinQuery;

public class GetCarByVinQuery : IRequest<CarDto>
{
    public required string IdentificationNumber { get; set; }
}