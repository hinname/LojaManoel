namespace LojaManoel.Domain.Entities;

public class Box
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Height { get; set; }
    public int Width { get; set; }
    public int Length { get; set; }
}