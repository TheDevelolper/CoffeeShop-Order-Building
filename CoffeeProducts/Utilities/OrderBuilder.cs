using CoffeeProducts.Decorators;
using CoffeeProducts.Enums;
using CoffeeProducts.Products;
using CoffeeShopBuilder;

namespace CoffeeProducts.Utilities;
public class OrderBuilder
{
    private IOrder _order = new Order();

    public OrderBuilder()
    {
    }

    public OrderBuilder AddBeverage(IBeverage beverage)
    {
        _order.Beverages.Add(beverage);
        return this;
    }

    public OrderBuilder ApplyDeal(Deal deal)
    {
        _order = deal switch
        {
            Deal.ByOneGetCheapestFree => new BuyTwoGetCheapestOneFreeOrderDecorator(_order),
            _ => throw new NotImplementedException($"Deal {deal} is not implemented.")
        };

        return this;
    }

    public IOrder Build()
    {

        return _order;
    }
}