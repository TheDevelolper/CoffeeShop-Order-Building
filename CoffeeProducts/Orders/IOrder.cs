using CoffeeProducts.Products;

namespace CoffeeShopBuilder
{
    public interface IOrder
    {
        List<IBeverage> Beverages { get; set; }
        decimal Cost { get; }
    }
}