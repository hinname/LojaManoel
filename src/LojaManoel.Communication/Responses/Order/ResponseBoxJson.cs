using LojaManoel.Communication.Responses.Product;

namespace LojaManoel.Communication.Responses.Order;

public class ResponseBoxJson
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<ResponseProductJson> Products { get; set; } = [];
}