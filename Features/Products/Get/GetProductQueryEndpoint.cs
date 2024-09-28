using CQRS_MinimalAPI.Base;
using CQRS_MinimalAPI.Base.Extentions;
using FluentResults;

using MediatR;

namespace CQRS_MinimalAPI.Features.Products.Get;

internal class GetProductQueryEndpoint : IEndpointBuilder
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("/products/{id}", async (
            IMediator mediator,
            [AsParameters] GetProductQuery query,
            CancellationToken cancellationToken
            ) =>
        {
            var result = await mediator.Send(query, cancellationToken);
            return result.ToHttpResult();
        }).Produces<GetProductResponse>().ProducesProblem(StatusCodes.Status400BadRequest).WithTags("Products");
    }
}