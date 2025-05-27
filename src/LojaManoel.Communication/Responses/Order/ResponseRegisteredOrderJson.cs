namespace LojaManoel.Communication.Responses.Order;

public class ResponseRegisteredOrderJson
{
    public string OrderId { get; set; } = string.Empty;
    public long InternalId { get; set; }
}