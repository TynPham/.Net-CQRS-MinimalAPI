using FluentResults;
using MediatR;

namespace CQRS_MinimalAPI.Messaging.Command;

public interface ICommand<TResponse>: IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;