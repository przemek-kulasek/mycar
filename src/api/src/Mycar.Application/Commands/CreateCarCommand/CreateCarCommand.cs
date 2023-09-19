using MediatR;
using Mycar.Application.Dtos;

namespace Mycar.Application.Commands.CreateCarCommand;

public class CreateCarCommand : IRequest<Guid>
{
    public required CarDto Car { get; set; }
}