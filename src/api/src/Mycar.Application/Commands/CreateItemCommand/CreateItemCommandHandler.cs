using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mycar.Application.Commands.CreateOperationCommand;
using Mycar.Domain;
using Mycar.Domain.Maintenance;

namespace Mycar.Application.Commands.CreateItemCommand;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Guid>
{
    private readonly ILogger<CreateOperationCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IMycarContext _mycarContext;

    public CreateItemCommandHandler(IMycarContext mycarContext, IMapper mapper,
        ILogger<CreateOperationCommandHandler> logger)
    {
        _mycarContext = mycarContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var itemExists = await _mycarContext.Items.AnyAsync(
            x => x.Operation.CarId == request.CarId && x.OperationId == request.OperationId && x.Id == request.Item.Id,
            cancellationToken);

        if (itemExists) throw new ValidationException("Item already exist.");

        var newItem = _mapper.Map<Item>(request.Item);
        await _mycarContext.AddAsync(newItem, cancellationToken);
        await _mycarContext.CommitAsync(cancellationToken);
        _logger.LogInformation("Item has been created. Id: {Id}", newItem.Id);

        return newItem.Id;
    }
}