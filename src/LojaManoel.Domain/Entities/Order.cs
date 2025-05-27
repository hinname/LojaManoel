namespace LojaManoel.Domain.Entities;

public class Order
{
    public long Id { get; set; }
    public string OrderId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}