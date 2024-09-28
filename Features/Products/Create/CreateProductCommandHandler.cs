using CQRS_MinimalAPI.Context;
using CQRS_MinimalAPI.Messaging.Command;
using CQRS_MinimalAPI.Model;
using FluentResults;

namespace CQRS_MinimalAPI.Features.Products.Create;

internal sealed class CreateProductCommandHandler(AppDbContext context) : ICommandHandler<CreateProductCommand, int>
{
    public async Task<Result<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            Name = request.Request.Name,
            Detail = request.Request.Detail,
            Price = request.Request.Price,
            Quantity = request.Request.Quantity
        };

        context.Products.Add(product);
        await context.SaveChangesAsync(cancellationToken);
        
        return Result.Ok(product.Id);
    }
}