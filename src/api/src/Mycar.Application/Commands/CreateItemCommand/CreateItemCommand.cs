using MediatR;
using Mycar.Application.Dtos;

namespace Mycar.Application.Commands.CreateItemCommand
{
    public class CreateItemCommand : IRequest
    {
        public required ItemDto Item { get; set; }
    }
}
