using CQRS_MinimalAPI.Context;
using CQRS_MinimalAPI.Messaging.Command;
using FluentResults;

namespace CQRS_MinimalAPI.Features.Products.Delete;

internal sealed class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, bool>
{
    private readonly AppDbContext _context;
    
    public DeleteProductCommandHandler(AppDbContext context)
    {
        this._context = context;
    }
    
    public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.id);
        if (product == null)
        {
            return false;
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}