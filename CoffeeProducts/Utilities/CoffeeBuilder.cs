using CoffeeProducts.Decorators;
using CoffeeProducts.Enums;
using CoffeeProducts.Products;

namespace CoffeeProducts.Utilities;

public class CoffeeBuilder: ICoffeeBuilder
{
    IBeverage beverage;
    public CoffeeBuilder()
    {
        beverage = new SmallCoffee(); // Base beverage cost is 0.10 pence
    }

    public ICoffeeBuilder WithMilk(MilkType milkType)
    {
        beverage = milkType switch
        {
            MilkType.FullFat => beverage, // No change for full-fat milk
            MilkType.Soy => new SoyMilkBeverageDecorator(beverage), // Wrap in SoyMilkDecorator
            MilkType.Almond => throw new NotImplementedException("Almond milk not implemented yet"),
            MilkType.Oat => new OatMilkBeverageDecorator(beverage), // Wrap in SoyMilkDecorator
            _ => throw new ArgumentOutOfRangeException(nameof(milkType), "Invalid milk type")
        };

        return this;
    }

    public ICoffeeBuilder WithSize(BeverageSize size)
    {
        beverage = size switch
        {
            BeverageSize.Small => beverage, // No change for small size
            BeverageSize.Medium => new MediumBeverageDecorator(beverage), // Wrap in MediumBeverage decorator
            BeverageSize.Large => throw new NotImplementedException("Large size not implemented yet"),
            _ => throw new ArgumentOutOfRangeException(nameof(size), "Invalid beverage size")
        };
        return this;
    }

    public IBeverage Build()
    {
        return beverage;
    }
}
