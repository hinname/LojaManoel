namespace LojaManoel.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}