using FluentValidation;
using MediatR;

namespace Mycar.WebAPI.Pipelines;

public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipeline(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return next();

        var validationContext = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(validator => validator.Validate(validationContext))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        if (!failures.Any()) return next();

        throw new ValidationException(failures);
    }
}