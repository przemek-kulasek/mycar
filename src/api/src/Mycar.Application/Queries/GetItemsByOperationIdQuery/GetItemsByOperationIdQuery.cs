using MediatR;
using Mycar.Application.Dtos;

namespace Mycar.Application.Queries.GetItemsByOperationIdQuery
{
    public class GetItemsByOperationIdQuery : IRequest<ICollection<ItemDto>>
    {
        public Guid OperationId { get; set; }
    }
}
