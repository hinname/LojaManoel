using LojaManoel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LojaManoel.Infrastructure.DataAccess;

internal class LojaManoelDbContext: DbContext
{
    public LojaManoelDbContext(DbContextOptions options) : base(options)
    {}
    public DbSet<Order> Orders { get; set; }
}