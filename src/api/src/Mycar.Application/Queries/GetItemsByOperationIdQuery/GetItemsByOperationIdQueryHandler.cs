using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Mycar.Application.Dtos;
using Mycar.Common.Exceptions;
using Mycar.Domain.Maintenance;
using Mycar.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mycar.Application.Queries.GetItemsByOperationIdQuery
{
    public class GetItemsByOperationIdQueryHandler : IRequestHandler<GetItemsByOperationIdQuery, ICollection<ItemDto>>
    {
        private readonly IMycarContext _mycarContext;
        private readonly IMapper _mapper;
        private readonly ILogger<GetItemsByOperationIdQueryHandler> _logger;

        public GetItemsByOperationIdQueryHandler(IMycarContext mycarContext, IMapper mapper, ILogger<GetItemsByOperationIdQueryHandler> logger)
        {
            _mycarContext = mycarContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ICollection<ItemDto>> Handle(GetItemsByOperationIdQuery request, CancellationToken cancellationToken)
        {
            var operations = await GeItemsByOperationId(request.OperationId, cancellationToken) ??
                      throw new NotFoundException(nameof(Item), request.OperationId);

            return _mapper.Map<ICollection<ItemDto>>(operations);
        }

        private async Task<ICollection<Item>> GeItemsByOperationId(Guid operationId, CancellationToken cancellationToken)
        {
            return await _mycarContext.Items.AsNoTracking().Where(x => x.OperationId == operationId).ToListAsync(cancellationToken);
        }
    }
}
