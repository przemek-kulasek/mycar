using MediatR;
using Mycar.Application.Dtos;

namespace Mycar.Application.Commands.CreateCarCommand
{
    public class CreateCarCommand : IRequest<string>
    {
        public CarDto Car { get; set; }
    }
}
