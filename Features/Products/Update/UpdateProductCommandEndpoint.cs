using CQRS_MinimalAPI.Base;
using CQRS_MinimalAPI.Base.Extentions;
using MediatR;

namespace CQRS_MinimalAPI.Features.Products.Update;

internal class UpdateProductCommandEndpoint : IEndpointBuilder
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPut("/products/{id}", async (
            IMediator mediator,
            [AsParameters] UpdateProductCommand command,
            CancellationToken cancellationToken
            ) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            return result.ToHttpResult();
        }).Produces<UpdateProductRequest>().ProducesProblem(StatusCodes.Status400BadRequest).WithTags("Products");
    }
}