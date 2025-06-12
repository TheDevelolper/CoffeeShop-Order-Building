using CoffeeProducts.Products;

namespace CoffeeProducts.Decorators;

internal class OatMilkDecorator : IBeverage
{
    private readonly IBeverage beverage;
    public decimal Cost => beverage.Cost + 0.40m; // Oat milk costs 40 pence
    internal OatMilkDecorator(IBeverage beverage)
    {
        this.beverage = beverage;
    }
}
