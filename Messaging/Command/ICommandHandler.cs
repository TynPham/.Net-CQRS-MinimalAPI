using FluentResults;
using MediatR;

namespace CQRS_MinimalAPI.Messaging.Command;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>> where TCommand : ICommand<TResponse>;