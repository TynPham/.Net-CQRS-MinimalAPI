namespace CQRS_MinimalAPI.Features.Products.GetList;

internal sealed record GetListProductResponse
(
   int Id,
   string Name,
   string Detail,
   decimal Price,
   int Quantity
);