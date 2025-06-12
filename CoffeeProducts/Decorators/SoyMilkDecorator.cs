using CoffeeProducts.Products;

namespace CoffeeProducts.Decorators;

internal class SoyMilkDecorator : IBeverage
{
    private readonly IBeverage beverage;
    public decimal Cost => beverage.Cost + 0.30m; // Soy milk costs 30 pence
    internal SoyMilkDecorator(IBeverage beverage)
    {
        this.beverage = beverage;
    }
}
