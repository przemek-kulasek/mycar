using MediatR;
using Mycar.Application.Dtos;

namespace Mycar.Application.Commands.CreateOperationCommand
{
    public class CreateOperationCommand : IRequest
    {
        public required OperationDto Operation { get; set; }
    }
}
