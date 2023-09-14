using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mycar.Application.Dtos;
using Mycar.Application.Queries.GetItemsByOperationIdQuery;
using Mycar.Domain;
using Mycar.Domain.Cars;

namespace Mycar.Application.Queries.GetCarHistoryByVinQuery
{
    public class GetCarHistoryByVinQueryHandler : IRequestHandler<GetCarHistoryByVinQuery, CarHistoryDto>
    {
        private readonly IMycarContext _mycarContext;
        private readonly IMapper _mapper;
        private readonly ILogger<GetItemsByOperationIdQueryHandler> _logger;

        public GetCarHistoryByVinQueryHandler(IMycarContext mycarContext, IMapper mapper, ILogger<GetItemsByOperationIdQueryHandler> logger)
        {
            _mycarContext = mycarContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CarHistoryDto> Handle(GetCarHistoryByVinQuery request, CancellationToken cancellationToken)
        {
            var carWithHistory = await GeCarWithHistory(request.Vin, cancellationToken);
            return _mapper.Map<CarHistoryDto>(carWithHistory);
        }

        private async Task<Car?> GeCarWithHistory(string vin, CancellationToken cancellationToken)
        {
            var carWithHistory = 
                await _mycarContext.Cars
                .Include(x => x.Operations)
                .ThenInclude(x => x.Items)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.IdentificationNumber == vin, cancellationToken: cancellationToken);

            return carWithHistory;
        }
    }
}
