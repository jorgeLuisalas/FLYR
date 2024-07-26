namespace SupermarketCheckout.Service
{
    using Microsoft.Extensions.DependencyInjection;
    using SupermarketCheckout.Data.Repositories;
    using SupermarketCheckout.Service.Services;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSupermarketServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddTransient<ICheckoutService, CheckoutService>();
            return services;
        }
    }
}
