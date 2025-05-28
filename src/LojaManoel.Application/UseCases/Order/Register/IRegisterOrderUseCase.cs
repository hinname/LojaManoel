using LojaManoel.Communication.Requests;
using LojaManoel.Communication.Requests.Order;
using LojaManoel.Communication.Responses.Order;

namespace LojaManoel.Application.UseCases.Order.Register;

public interface IRegisterOrderUseCase
{
    public Task<ResponseOrdersJson> Execute(RequestOrdersJson request);
}