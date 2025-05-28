using LojaManoel.Domain.Repositories;

namespace LojaManoel.Infrastructure.DataAccess;

internal class UnitOfWork : IUnitOfWork
{
    private readonly LojaManoelDbContext _dbContext;
    public UnitOfWork(LojaManoelDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}