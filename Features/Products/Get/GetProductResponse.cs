namespace CQRS_MinimalAPI.Features.Products.Get;

internal sealed record GetProductResponse
(
    int Id,
    string Name,
    string Detail,
    decimal Price,
    int Quantity
);