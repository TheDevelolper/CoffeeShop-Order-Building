﻿using CoffeeProducts.Products;

namespace CoffeeProducts.Decorators;

internal class SoyMilkBeverageDecorator : IBeverage
{
    private readonly IBeverage beverage;
    public decimal Cost => beverage.Cost + 0.30m; // Soy milk costs 30 pence

    public string? Description => $"{beverage.Description} with Soy Milk";

    internal SoyMilkBeverageDecorator(IBeverage beverage)
    {
        this.beverage = beverage;
    }
}
