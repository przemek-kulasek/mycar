using MediatR;

namespace Mycar.Application.Commands.DeleteCarCommand
{
    public class DeleteCarCommand : IRequest
    {
        public string Vin {  get; set; }
    }
}
