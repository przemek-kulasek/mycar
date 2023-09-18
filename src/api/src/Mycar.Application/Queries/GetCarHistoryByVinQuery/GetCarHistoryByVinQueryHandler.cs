using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mycar.Application.Dtos;
using Mycar.Application.Queries.GetItemsByOperationIdQuery;
using Mycar.Common.Exceptions;
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
            var carWithHistory = await GetCarWithHistory(request.Vin, cancellationToken) ??
                      throw new NotFoundException(nameof(Car), request.Vin);

            return _mapper.Map<CarHistoryDto>(carWithHistory);
        }

        private async Task<Car?> GetCarWithHistory(string vin, CancellationToken cancellationToken)
        {
            var carWithHistory = 
                await _mycarContext.Cars
                .Where(x => x.IdentificationNumber == vin)
                .Include(x => x.Operations)
                .ThenInclude(x => x.Items)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return carWithHistory;
        }
    }
}
