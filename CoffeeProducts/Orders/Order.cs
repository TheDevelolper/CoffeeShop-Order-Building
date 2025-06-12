using CoffeeProducts.Products;

namespace CoffeeShopBuilder
{
    public class Order: IOrder
    {
        public List<IBeverage> Beverages { get; set; } = new List<IBeverage>();
        public decimal Cost => Beverages.Sum(b => b.Cost);
    }
}