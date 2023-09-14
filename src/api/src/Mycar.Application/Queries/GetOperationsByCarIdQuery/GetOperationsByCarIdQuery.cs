using MediatR;
using Mycar.Application.Dtos;

namespace Mycar.Application.Queries.GetOperationsByCarIdQuery
{
    public class GetOperationsByCarIdQuery : IRequest<ICollection<OperationDto>>
    {
        public Guid CarId { get; set; }
    }
}
