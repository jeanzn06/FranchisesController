using Microsoft.EntityFrameworkCore;
using Franchise.Api.Models;

namespace Franchise.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

public DbSet<Franchise.Api.Models.Franchise> Franchises { get; set; }

    public DbSet<Branch> Branches { get; set; }

    public DbSet<Product> Products { get; set; }
}