using CQRS_MinimalAPI.Base;
using CQRS_MinimalAPI.Base.Extentions;
using MediatR;

namespace CQRS_MinimalAPI.Features.Products.Create;

internal class CreateProductCommandEndpoint : IEndpointBuilder
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("/products", async (
            IMediator mediator,
            [AsParameters] CreateProductCommand command,
            CancellationToken cancellationToken
        ) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            return result.ToHttpResult();
        }).Produces<int>().ProducesProblem(StatusCodes.Status400BadRequest).WithTags("Products");
    }
}