
using CoffeeProducts.Enums;
using CoffeeProducts.Products;
using CoffeeProducts.Utilities;

namespace Decorator.Tests;

[TestClass]
public sealed class Builder_Decorator_Tests
{
    [TestMethod]
    public void Calculates_Medium_Coffee_With_Soy_Milk()
    {
        IBeverage beverage = new CoffeeBuilder()
            // small beverage cost is 0.10 pence
            .WithSize(BeverageSize.Medium) // medium 60 pence 
            .WithMilk(MilkType.Soy) // Add soy milk 30 pence
            .Build();

        Assert.IsNotNull(beverage);
        Assert.AreEqual(1.0m, beverage.Cost);
        Assert.AreEqual("Medium Coffee with Soy Milk", beverage.Description);
    }

    [TestMethod]
    public void Calculates_Medium_Coffee_With_Oat_Milk()
    {
        IBeverage beverage = new CoffeeBuilder()
            // small beverage cost is 0.10 pence
            .WithSize(BeverageSize.Medium) // medium 60 pence 
            .WithMilk(MilkType.Oat) // Add oat milk 40 pence
            .Build();

        Assert.IsNotNull(beverage);
        Assert.AreEqual(1.10m, beverage.Cost);
        Assert.AreEqual("Medium Coffee with Oat Milk", beverage.Description);
    }

    [TestMethod]
    public void Buy_Two_Get_Cheapest_One_Free()
    {
        var orderBuilder = new OrderBuilder();
        IOrder order =
                orderBuilder
                .AddBeverage(
                    new CoffeeBuilder()
                    .WithSize(BeverageSize.Medium)
                    .WithMilk(MilkType.Oat) // 1.10m
                    .Build()
                    )
                .AddBeverage(
                    new CoffeeBuilder()
                    .WithSize(BeverageSize.Medium)
                    .WithMilk(MilkType.Soy) // 1.0m
                    .Build()
                    )
                .ApplyDeal(Deal.ByOneGetCheapestFree)
                .Build();

        Assert.IsNotNull(order);
        // order without deal would be 2.10m
        // with deal, the cheapest one is free, so we only pay for the more expensive one 1.10m
        Assert.AreEqual(1.10m, order.Cost); 
        Assert.AreEqual(2, order.Beverages.Count);

        // retains the descriptions of the beverages in the correct order by internally cloning the beverages list
        Assert.AreEqual("Medium Coffee with Oat Milk", order.Beverages[0].Description);
        Assert.AreEqual("Medium Coffee with Soy Milk", order.Beverages[1].Description);
    }

    [TestMethod]
    public void Buy_Three_Get_Cheapest_One_Free()
    {
        var orderBuilder = new OrderBuilder();
        IOrder order =
                orderBuilder
                .AddBeverage(
                    new CoffeeBuilder()
                    .WithSize(BeverageSize.Medium)
                    .WithMilk(MilkType.Oat) // 1.10m
                    .Build()
                    )
                .AddBeverage(
                    new CoffeeBuilder()
                    .WithSize(BeverageSize.Medium)
                    .WithMilk(MilkType.Oat) // 1.10m
                    .Build()
                    )
                .AddBeverage(
                    new CoffeeBuilder()
                    .WithSize(BeverageSize.Medium)
                    .WithMilk(MilkType.Soy) // 1.0m
                    .Build()
                    )
                .ApplyDeal(Deal.ByOneGetCheapestFree)
                .Build();

        Assert.IsNotNull(order);
        Assert.AreEqual(2.20m, order.Cost); // order without deal would be 3.20m
        Assert.AreEqual(3, order.Beverages.Count);

        // retains the descriptions of the beverages in the correct order by internally cloning the beverages list
        Assert.AreEqual("Medium Coffee with Oat Milk", order.Beverages[0].Description);
        Assert.AreEqual("Medium Coffee with Oat Milk", order.Beverages[1].Description);
        Assert.AreEqual("Medium Coffee with Soy Milk", order.Beverages[2].Description);
    }

    [TestMethod]
    public void Buy_Four_Get_Cheapest_Two_Free()
    {
        var orderBuilder = new OrderBuilder();
        IOrder order =
                orderBuilder
                .AddBeverage(
                    new CoffeeBuilder()
                    .WithSize(BeverageSize.Medium)
                    .WithMilk(MilkType.Oat) // 1.10m
                    .Build()
                    )
                .AddBeverage(
                    new CoffeeBuilder()
                    .WithSize(BeverageSize.Medium)
                    .WithMilk(MilkType.Oat) // 1.10m
                    .Build()
                    )
                .AddBeverage(
                    new CoffeeBuilder()
                    .WithSize(BeverageSize.Medium)
                    .WithMilk(MilkType.Soy) // 1.0m
                    .Build()
                    )
                 .AddBeverage(
                    new CoffeeBuilder()
                    .WithSize(BeverageSize.Medium)
                    .WithMilk(MilkType.Soy) // 1.0m
                    .Build()
                    )
                .ApplyDeal(Deal.ByOneGetCheapestFree)
                .Build();

        Assert.IsNotNull(order);
        Assert.AreEqual(2.20m, order.Cost); // order without deal would be 4.20m
        Assert.AreEqual(4, order.Beverages.Count);

        // retains the descriptions of the beverages in the correct order by internally cloning the beverages list
        Assert.AreEqual("Medium Coffee with Oat Milk", order.Beverages[0].Description);
        Assert.AreEqual("Medium Coffee with Oat Milk", order.Beverages[1].Description);
        Assert.AreEqual("Medium Coffee with Soy Milk", order.Beverages[2].Description);
        Assert.AreEqual("Medium Coffee with Soy Milk", order.Beverages[3].Description);
    }

}