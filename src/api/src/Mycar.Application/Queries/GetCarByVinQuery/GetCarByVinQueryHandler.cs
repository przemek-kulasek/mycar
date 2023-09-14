using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mycar.Application.Dtos;
using Mycar.Common.Exceptions;
using Mycar.Domain;
using Mycar.Domain.Cars;

namespace Mycar.Application.Queries.GetCarByVinQuery
{
    public class GetCarByVinQueryHandler : IRequestHandler<GetCarByVinQuery, CarDto>
    {
        private readonly IMycarContext _mycarContext;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCarByVinQueryHandler> _logger;


        public GetCarByVinQueryHandler(IMycarContext mycarContext, IMapper mapper, ILogger<GetCarByVinQueryHandler> logger)
        {
            _mycarContext = mycarContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CarDto> Handle(GetCarByVinQuery request, CancellationToken cancellationToken)
        {
            var car = await GetCarByVin(request.IdentificationNumber, cancellationToken) ??
                      throw new NotFoundException(nameof(Car), request.IdentificationNumber);

            return _mapper.Map<CarDto>(car);
        }

        private async Task<Car?> GetCarByVin(string vin, CancellationToken cancellationToken)
        {
            return await _mycarContext.Cars.AsNoTracking().FirstOrDefaultAsync(x => x.IdentificationNumber == vin, cancellationToken: cancellationToken);
        }
    }
}
