using CQRS_MinimalAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MinimalAPI.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
}