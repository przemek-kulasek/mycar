using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Mycar.Application.Queries.GetCarByVinQuery;
using Mycar.Common.Exceptions;
using Mycar.Domain;

namespace Mycar.Application.Commands.DeleteCarCommand;

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
{
    private readonly ILogger<GetCarByVinQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IMycarContext _mycarContext;

    public DeleteCarCommandHandler(IMycarContext mycarContext, IMapper mapper, ILogger<GetCarByVinQueryHandler> logger)
    {
        _mycarContext = mycarContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        var cars = _mycarContext.Cars.Where(x => x.Id == request.Id);

        if (!cars.Any()) throw new NotFoundException("VIN", request.Id);

        _mycarContext.RemoveRange(cars);
        await _mycarContext.CommitAsync(cancellationToken);
        _logger.LogInformation("Car has been created. Id: {Id}", request.Id);
    }
}