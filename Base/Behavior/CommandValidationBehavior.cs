using CQRS_MinimalAPI.Base.Extentions;
using CQRS_MinimalAPI.Messaging.Command;
using CQRS_MinimalAPI.Shared;
using FluentResults;
using FluentValidation;
using MediatR;

namespace CQRS_MinimalAPI.Base.Behavior;

public sealed class CommandValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
    where TResponse : ResultBase, new()
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public CommandValidationBehavior(IEnumerable<IValidator<TRequest>> validators) =>
        _validators = validators;

    public async Task<TResponse> Handle(
        TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next();

        var errorsDictionary = new Dictionary<string, string[]>();

        foreach (var item in _validators)
        {
            var validationResult = await item.ValidateAsync(request, cancellationToken);

            var errors = validationResult.Errors
                                .Where(x => x != null)
                                .GroupBy(
                                        x => x.PropertyName,
                                        x => x.ErrorMessage,
                                        (propertyName, errorMessages) => new
                                        {
                                            Key = propertyName.ToCamelCase(),
                                            Values = errorMessages.Distinct().ToArray()
                                        });

            foreach (var error in errors)
            {
                errorsDictionary[error.Key] = error.Values;
            }
        }

        if (errorsDictionary.Count == 0)
            return await next();

        var result = new TResponse();
        result.Reasons.AddRange(errorsDictionary.Select(errorGroup => new ValidationError(errorGroup.Key, errorGroup.Value)));
        return result;
    }
}