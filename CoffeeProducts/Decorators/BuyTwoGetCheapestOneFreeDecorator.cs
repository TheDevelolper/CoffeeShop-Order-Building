using CoffeeProducts.Products;
using Decorator;

namespace CoffeeProducts.Decorators;

public class BuyTwoGetCheapestOneFreeDecorator: IOrder
{
    private IOrder _order;
    public decimal Cost => GetTotalCost();

    public List<IBeverage> Beverages
    {
        get => _order.Beverages;
        set => _order.Beverages = value;
    }

    private decimal GetTotalCost()
    {
        _order.Beverages.Sort((x, y) => x.Cost.CompareTo(y.Cost));

        if (_order.Beverages.Count % 2 == 0)
        {
            int firstN = (int)Math.Floor((decimal)_order.Beverages.Count / 2);
            var result = _order.Beverages
                .Take(firstN)
                .Sum(beverage => beverage.Cost);

            return result;
        }

        return _order.Cost;
    }

    public BuyTwoGetCheapestOneFreeDecorator(IOrder order)
    {
        order = order ?? throw new ArgumentNullException(nameof(order), "Order cannot be null");
     
        _order = order;
    }
}