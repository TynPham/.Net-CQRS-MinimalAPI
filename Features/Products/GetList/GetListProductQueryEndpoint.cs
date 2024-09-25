using CQRS_MinimalAPI.Base;
using CQRS_MinimalAPI.Base.Extentions;
using MediatR;

namespace CQRS_MinimalAPI.Features.Products.GetList;

internal class GetListProductQueryEndpoint : IEndpointBuilder
{
   public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
   {
      routeBuilder.MapGet("/products", async (
          IMediator mediator,
          [AsParameters] GetListProductQuery query,
            CancellationToken cancellationToken
      ) =>
      {
         var result = await mediator.Send(query, cancellationToken);
         return result.ToHttpResult();
      }).Produces<List<GetListProductResponse>>().ProducesProblem(StatusCodes.Status400BadRequest);
   }
}