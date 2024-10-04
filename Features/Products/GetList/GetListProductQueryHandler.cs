using CQRS_MinimalAPI.Base;
using CQRS_MinimalAPI.Context;
using CQRS_MinimalAPI.Messaging.Query;
using FluentResults;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MinimalAPI.Features.Products.GetList;

internal sealed class GetListProductQueryHandler(ReadOnlyDataContext context) : IQueryHandler<GetListProductQuery, InfoPagedList<GetListProductResponse>> 
{
    public async Task<Result<InfoPagedList<GetListProductResponse>>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
    {
        
        var query = context.Products;
        var totalCount = await query.CountAsync(cancellationToken);

        var products = await context.Products.ToListAsync(cancellationToken);

        var response = products.Adapt<List<GetListProductResponse>>();

        var pagedList = new InfoPagedList<GetListProductResponse>(response, totalCount, request.Page, request.PageSize);
        return Result.Ok(pagedList);
    }
}