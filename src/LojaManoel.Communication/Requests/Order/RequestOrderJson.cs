using LojaManoel.Communication.Requests.Product;

namespace LojaManoel.Communication.Requests.Order;

public class RequestOrderJson
{
    public string OrderId { get; set; }
    public IList<RequestProductJson> Products { get; set; }
}