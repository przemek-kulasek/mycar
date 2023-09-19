using MediatR;

namespace Mycar.Application.Commands.DeleteCarCommand;

public class DeleteCarCommand : IRequest
{
    public required Guid Id { get; set; }
}