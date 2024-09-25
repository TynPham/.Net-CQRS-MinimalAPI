using CQRS_MinimalAPI.Messaging.Query;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MinimalAPI.Features.Products.GetList;

internal sealed record GetListProductQuery : IQuery<List<GetListProductResponse>>;