using CQRS_MinimalAPI.Context;
using CQRS_MinimalAPI.Messaging.Query;
using FluentResults;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MinimalAPI.Features.Products.Get;

 internal sealed class GetProductQueryHandler (ReadOnlyDataContext context): IQueryHandler<GetProductQuery, GetProductResponse>
{
    public async Task<Result<GetProductResponse>> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == query.id, cancellationToken);

        if (product is null)
        {
            return Result.Fail("Product not found.");
        }

        var response = product.Adapt<GetProductResponse>();

        return Result.Ok(response);
    }
}