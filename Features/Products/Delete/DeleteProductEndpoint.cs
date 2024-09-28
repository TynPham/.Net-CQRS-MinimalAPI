using CQRS_MinimalAPI.Base;
using CQRS_MinimalAPI.Base.Extentions;
using MediatR;

namespace CQRS_MinimalAPI.Features.Products.Delete;

internal class DeleteProductEndpoint : IEndpointBuilder
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapDelete("/products/{id}", async (
                IMediator mediator,
                [AsParameters] DeleteProductCommand command,
                CancellationToken cancellationToken
            ) =>
            {
                var result = await mediator.Send(command, cancellationToken);
                return result.ToHttpResult();
            }).ProducesProblem(StatusCodes.Status400BadRequest).ProducesProblem(StatusCodes.Status404NotFound)
            .WithTags("Products");
    }
}