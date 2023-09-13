using MediatR;

namespace Mycar.Application.Commands.DeleteCarCommand
{
    public class DeleteCarCommand : IRequest
    {
        public required string Vin {  get; set; }
    }
}
