using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mycar.Application.Dtos;
using Mycar.Common.Exceptions;
using Mycar.Domain;
using Mycar.Domain.Maintenance;

namespace Mycar.Application.Queries.GetItemsByOperationIdQuery;

public class GetItemsByOperationIdQueryHandler : IRequestHandler<GetItemsByOperationIdQuery, ICollection<ItemDto>>
{
    private readonly ILogger<GetItemsByOperationIdQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IMycarContext _mycarContext;

    public GetItemsByOperationIdQueryHandler(IMycarContext mycarContext, IMapper mapper,
        ILogger<GetItemsByOperationIdQueryHandler> logger)
    {
        _mycarContext = mycarContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ICollection<ItemDto>> Handle(GetItemsByOperationIdQuery request,
        CancellationToken cancellationToken)
    {
        var operations = await GeItemsByOperationId(request.CarId, request.OperationId, cancellationToken) ??
                         throw new NotFoundException(nameof(Item), request.OperationId);

        return _mapper.Map<ICollection<ItemDto>>(operations);
    }

    private async Task<ICollection<Item>> GeItemsByOperationId(Guid carId, Guid operationId,
        CancellationToken cancellationToken)
    {
        return await _mycarContext.Items.AsNoTracking()
            .Where(x => x.Operation.Car.Id == carId && x.OperationId == operationId).ToListAsync(cancellationToken);
    }
}