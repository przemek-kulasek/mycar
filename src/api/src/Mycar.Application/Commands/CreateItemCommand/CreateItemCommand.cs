using MediatR;
using Mycar.Application.Dtos;

namespace Mycar.Application.Commands.CreateItemCommand
{
    public class CreateItemCommand : IRequest<Guid>
    {
        public Guid CarId { get; set; }
        public Guid OperationId { get; set; }
        public required ItemDto Item { get; set; }
    }
}
