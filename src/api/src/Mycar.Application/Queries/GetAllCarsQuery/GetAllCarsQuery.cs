using MediatR;
using Mycar.Application.Dtos;

namespace Mycar.Application.Queries.GetAllCarsQuery
{
    public class GetAllCarsQuery : IRequest<ICollection<CarDto>>
    {
    }
}
