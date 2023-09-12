using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mycar.Application.Queries.GetCarByVinQuery;
using Mycar.Domain;
using Mycar.Domain.Cars;

namespace Mycar.Application.Commands.CreateCarCommand
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, string>
    {
        private readonly IMycarContext _mycarContext;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCarByVinQueryHandler> _logger;

        public CreateCarCommandHandler(IMycarContext mycarContext, IMapper mapper, ILogger<GetCarByVinQueryHandler> logger)
        {
            _mycarContext = mycarContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var carExists = await _mycarContext.Cars.AnyAsync(x => x.IdentificationNumber == request.Car.IdentificationNumber, cancellationToken: cancellationToken);

            if(carExists)
            {
                throw new ValidationException("Car already exist.");
            }

            var newCar = _mapper.Map<Car>(request.Car);
            await _mycarContext.AddAsync(newCar, cancellationToken);
            await _mycarContext.CommitAsync(cancellationToken);
            _logger.LogInformation("Car has been created. VIN: {IdentificationNumber}", newCar.IdentificationNumber);

            return newCar.IdentificationNumber;
        }
    }
}
