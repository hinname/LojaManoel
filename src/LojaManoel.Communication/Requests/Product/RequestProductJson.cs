namespace LojaManoel.Communication.Requests.Product;

public class RequestProductJson
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Height { get; set; }
    public int Width { get; set; }
    public int Length { get; set; }
}