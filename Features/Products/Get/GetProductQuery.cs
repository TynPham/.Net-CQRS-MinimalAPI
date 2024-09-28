using CQRS_MinimalAPI.Messaging.Query;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MinimalAPI.Features.Products.Get;

internal sealed record GetProductQuery([FromRoute] int id) : IQuery<GetProductResponse>;