using FluentResults;
using MediatR;

namespace CQRS_MinimalAPI.Messaging.Query;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>;