using LojaManoel.Communication.Requests.Order;

namespace LojaManoel.Communication.Requests;

public class RequestOrdersJson
{
    public List<RequestOrderJson> Orders { get; set; }
}