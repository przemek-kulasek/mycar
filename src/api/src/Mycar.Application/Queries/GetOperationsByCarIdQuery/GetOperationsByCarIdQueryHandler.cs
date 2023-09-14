using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mycar.Application.Dtos;
using Mycar.Application.Queries.GetCarByVinQuery;
using Mycar.Common.Exceptions;
using Mycar.Domain;
using Mycar.Domain.Maintenance;

namespace Mycar.Application.Queries.GetOperationsByCarIdQuery
{
    public class GetOperationsByCarIdQueryHandler : IRequestHandler<GetOperationsByCarIdQuery, ICollection<OperationDto>>
    {
        private readonly IMycarContext _mycarContext;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCarByVinQueryHandler> _logger;

        public GetOperationsByCarIdQueryHandler(IMycarContext mycarContext, IMapper mapper, ILogger<GetCarByVinQueryHandler> logger)
        {
            _mycarContext = mycarContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ICollection<OperationDto>> Handle(GetOperationsByCarIdQuery request, CancellationToken cancellationToken)
        {
            var operations = await GeOperationsByCarId(request.CarId, cancellationToken) ??
                      throw new NotFoundException(nameof(Operation), request.CarId);

            return _mapper.Map<ICollection<OperationDto>>(operations);
        }

        private async Task<ICollection<Operation>> GeOperationsByCarId(Guid carId, CancellationToken cancellationToken)
        {
            return await _mycarContext.Operations.AsNoTracking().Where(x => x.CarId == carId).ToListAsync(cancellationToken);
        }
    }
}
