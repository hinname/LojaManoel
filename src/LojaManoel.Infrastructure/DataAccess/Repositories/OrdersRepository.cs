using LojaManoel.Domain.Entities;
using LojaManoel.Domain.Repositories.Orders;

namespace LojaManoel.Infrastructure.DataAccess.Repositories;

internal class OrdersRepository: IOrdersWriteOnlyRepository
{
    private readonly LojaManoelDbContext _dbContext;
    public OrdersRepository(LojaManoelDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(Order order)
    {
        await _dbContext.Orders.AddAsync(order);
    }
}