using LojaManoel.Application.UseCases.Order.Register;
using Microsoft.Extensions.DependencyInjection;

namespace LojaManoel.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
    }

    private static void AddUseCases(this IServiceCollection services)
    {
        #region orders

        services.AddScoped<IRegisterOrderUseCase, RegisterOrderUseCase>();

        #endregion
    }
}