using FluentResults;
using MediatR;

namespace CQRS_MinimalAPI.Messaging.Query;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;