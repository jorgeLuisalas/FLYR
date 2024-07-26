using System;
using Microsoft.Extensions.DependencyInjection;
using SupermarketCheckout.Service;
using SupermarketCheckout.Service.Services;

class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSupermarketServices();
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var checkoutService = serviceProvider.GetService<ICheckoutService>();

        checkoutService.Scan("GR1");
        checkoutService.Scan("CF1");
        checkoutService.Scan("SR1");
        checkoutService.Scan("GR1");
        checkoutService.Scan("GR1");
        checkoutService.Scan("CF1");
        checkoutService.Scan("CF1");

        var total = checkoutService.Total();
        Console.WriteLine($"Total price: £{total}");
    }
}

