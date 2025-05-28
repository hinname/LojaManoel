using LojaManoel.Domain.Entities;

namespace LojaManoel.Domain.Repositories.Orders;

public interface IOrdersWriteOnlyRepository
{
    Task Add(Order order);
}