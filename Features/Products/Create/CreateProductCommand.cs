using System.Windows.Input;
using CQRS_MinimalAPI.Messaging.Command;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MinimalAPI.Features.Products.Create;

internal sealed record CreateProductCommand([FromBody] CreateProductRequest Request) : ICommand<int>;

internal sealed record CreateProductRequest(
    string Name,
    string Detail,
    decimal Price,
    int Quantity
);