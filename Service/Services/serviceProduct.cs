namespace SupermarketCheckout.Service.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using SupermarketCheckout.Data.Repositories;
    using SupermarketCheckout.Model.Models;

    public interface ICheckoutService
    {
        void Scan(string productCode);
        decimal Total();
    }

    public class CheckoutService : ICheckoutService
    {
        private readonly IProductRepository _productRepository;
        private readonly List<CartItem> _cartItems;

        public CheckoutService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _cartItems = new List<CartItem>();
        }

        public void Scan(string productCode)
        {
            var product = _productRepository.GetProducts().FirstOrDefault(p => p.Code == productCode);
            if (product != null)
            {
                var cartItem = _cartItems.FirstOrDefault(ci => ci.Product.Code == productCode);
                if (cartItem != null)
                {
                    cartItem.Quantity++;
                }
                else
                {
                    _cartItems.Add(new CartItem { Product = product, Quantity = 1 });
                }
            }
        }

        public decimal Total()
        {
            decimal total = 0.0M;

            foreach (var item in _cartItems)
            {
                total += GetPriceForItem(item);
            }

            return total;
        }

        private decimal GetPriceForItem(CartItem item)
        {
            decimal price = item.Product.Price * item.Quantity;

            if (item.Product.Code == "GR1")
            {
                price = (item.Quantity / 2 + item.Quantity % 2) * item.Product.Price; 
            }
            else if (item.Product.Code == "SR1" && item.Quantity >= 3)
            {
                price = item.Quantity * 4.50M; 
            }
            else if (item.Product.Code == "CF1" && item.Quantity >= 3)
            {
                price = item.Quantity * item.Product.Price * 2 / 3; 
            }

            return price;
        }
    }
}
