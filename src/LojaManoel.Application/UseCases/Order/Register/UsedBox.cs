using LojaManoel.Communication.Responses.Product;

namespace LojaManoel.Application.UseCases.Order.Register;

public class UsedBox
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Height { get; set; }
    public int Width { get; set; }
    public int Length { get; set; }
    public int HeightUsed { get; set; }
    public int WidthUsed { get; set; }
    public int LengthUsed { get; set; }
    
    public List<ResponseProductJson> Products { get; set; } = [];
}