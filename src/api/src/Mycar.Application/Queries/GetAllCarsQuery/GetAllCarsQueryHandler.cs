using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mycar.Application.Dtos;
using Mycar.Application.Queries.GetCarByVinQuery;
using Mycar.Domain;

namespace Mycar.Application.Queries.GetAllCarsQuery
{
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, ICollection<CarDto>>
    {
        private readonly IMycarContext _mycarContext;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCarByVinQueryHandler> _logger;


        public GetAllCarsQueryHandler(IMycarContext mycarContext, IMapper mapper, ILogger<GetCarByVinQueryHandler> logger)
        {
            _mycarContext = mycarContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ICollection<CarDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = await _mycarContext.Cars.AsNoTracking().ToListAsync(cancellationToken);
            _logger.LogInformation("Retrieved {Count} cars.", cars.Count);
            return _mapper.Map<ICollection<CarDto>>(cars);
        }
    }
}
