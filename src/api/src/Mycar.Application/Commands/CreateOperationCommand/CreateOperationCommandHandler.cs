using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mycar.Domain;
using Mycar.Domain.Maintenance;

namespace Mycar.Application.Commands.CreateOperationCommand
{
    public class CreateOperationCommandHandler : IRequestHandler<CreateOperationCommand, Guid>
    {
        private readonly IMycarContext _mycarContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOperationCommandHandler> _logger;

        public CreateOperationCommandHandler(IMycarContext mycarContext, IMapper mapper, ILogger<CreateOperationCommandHandler> logger)
        {
            _mycarContext = mycarContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
        {
            var operationExists = await _mycarContext.Operations.AnyAsync(x => x.Id == request.Operation.Id, cancellationToken: cancellationToken);

            if (operationExists)
            {
                throw new ValidationException("Operation already exist.");
            }

            var newOperation = _mapper.Map<Operation>(request.Operation);
            await _mycarContext.AddAsync(newOperation, cancellationToken);
            await _mycarContext.CommitAsync(cancellationToken);
            _logger.LogInformation("Operation has been created. Id: {Id}", newOperation.Id);

            return newOperation.Id;
        }
    }
}
