using CoffeeProducts.Products;

namespace Decorator
{
    public interface IOrder
    {
        List<IBeverage> Beverages { get; set; }
        decimal Cost { get; }
    }
}