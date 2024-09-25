using CQRS_MinimalAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MinimalAPI.Context;

public sealed class ReadOnlyDataContext
{
    private readonly AppDbContext _context;

    public ReadOnlyDataContext(AppDbContext context)
    {
        _context = context;
        _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public IQueryable<Product> Products => _context.Products.IgnoreAutoIncludes();
}
