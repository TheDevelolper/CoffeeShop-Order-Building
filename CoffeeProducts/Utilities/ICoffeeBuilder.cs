using CoffeeProducts.Enums;
using CoffeeProducts.Products;

namespace CoffeeProducts.Utilities;

public interface ICoffeeBuilder
{
    ICoffeeBuilder WithMilk(MilkType milkType);
    ICoffeeBuilder WithSize(BeverageSize size);
    IBeverage Build();
}