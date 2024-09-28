using CQRS_MinimalAPI.Context;
using CQRS_MinimalAPI.Messaging.Command;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MinimalAPI.Features.Products.Update;

internal sealed class UpdateProductCommandHandler(AppDbContext context) : ICommandHandler<UpdateProductCommand, int>
{
    public async Task<Result<int>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == command.id, cancellationToken);
        if (product == null)
        {
            return Result.Fail<int>($"Product with ID {command.id} not found.");
        }

        product.Name = command.body.Name;
        product.Detail = command.body.Detail;
        product.Price = command.body.Price;
        product.Quantity = command.body.Quantity;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Ok(product.Id);

    }
}