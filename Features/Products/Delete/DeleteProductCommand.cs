using CQRS_MinimalAPI.Messaging.Command;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MinimalAPI.Features.Products.Delete;

internal sealed record DeleteProductCommand([FromRoute] int id) : ICommand<bool>;