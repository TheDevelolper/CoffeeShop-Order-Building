using CoffeeProducts.Products;

namespace CoffeeProducts.Decorators;

internal class MediumBeverageDecorator : IBeverage
{
    private readonly IBeverage beverage;

    public decimal Cost => beverage.Cost + 0.60m; // Medium size costs 70 pence

    public string? Description => $"Medium {beverage.Description}";

    internal MediumBeverageDecorator(IBeverage beverage)
    {
        this.beverage = beverage;
    }
}
