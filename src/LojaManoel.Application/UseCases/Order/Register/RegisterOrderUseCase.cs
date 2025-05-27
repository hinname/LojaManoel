using LojaManoel.Communication.Requests.Order;
using LojaManoel.Communication.Responses.Order;

namespace LojaManoel.Application.UseCases.Order.Register;

public class RegisterOrderUseCase : IRegisterOrderUseCase
{
    public async Task<ResponseRegisteredOrderJson> Execute(RequestOrderJson request)
    {
        Validate(request);

        throw new NotImplementedException();
    }

    
    
    private void Validate(RequestOrderJson request)
    {
        // Check if products mesurements are valid
        if (request.Products == null || request.Products.Count == 0)
        {
            throw new ArgumentException("Order must contain at least one product.");
        }
        foreach (var product in request.Products)
        {
            if (product.Height == 0 || product.Width == 0 || product.Length == 0)
            {
                throw new ArgumentException("Product measurements must be greater than zero.");
            }
        }
    }
}