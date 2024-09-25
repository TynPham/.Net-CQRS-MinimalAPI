using CQRS_MinimalAPI.Context;
using CQRS_MinimalAPI.Messaging.Query;
using FluentResults;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MinimalAPI.Features.Products.GetList;

internal sealed class GetListProductQueryHandler(ReadOnlyDataContext context) : IQueryHandler<GetListProductQuery, List<GetListProductResponse>> 
{
    public async Task<Result<List<GetListProductResponse>>> Handle(GetListProductQuery query, CancellationToken cancellationToken)
    {
        var products = await context.Products.ToListAsync(cancellationToken);

        var response = products.Adapt<List<GetListProductResponse>>();

        return Result.Ok(response);
    }
}