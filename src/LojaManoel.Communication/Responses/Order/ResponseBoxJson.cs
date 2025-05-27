using LojaManoel.Communication.Responses.Product;

namespace LojaManoel.Communication.Responses.Order;

public class ResponseBoxJson
{
    public long BoxId { get; set; }
    public string BoxName { get; set; } = string.Empty;
    public string BoxDescription { get; set; } = string.Empty;
    public IList<ResponseProductJson> Products { get; set; } = new List<ResponseProductJson>();
}