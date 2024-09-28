using CQRS_MinimalAPI.Messaging.Command;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MinimalAPI.Features.Products.Update;

internal sealed record UpdateProductCommand([FromRoute] int id, [FromBody] UpdateProductRequest body) : ICommand<int>;

internal sealed record UpdateProductRequest (
    string Name,
    string Detail,
    decimal Price,
    int Quantity
);