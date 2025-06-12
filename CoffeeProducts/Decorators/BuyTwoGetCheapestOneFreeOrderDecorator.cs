using CoffeeProducts.Products;
using Decorator;

namespace CoffeeProducts.Decorators;

public class BuyTwoGetCheapestOneFreeOrderDecorator: IOrder
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

        if (_order.Beverages.Count % 2 == 0)
        {
            var sortedBeveragesByCost = new List<IBeverage>(_order.Beverages);
            sortedBeveragesByCost.Sort((x, y) => x.Cost.CompareTo(y.Cost));

            int firstN = (int)Math.Floor((decimal)sortedBeveragesByCost.Count / 2);
            var result = sortedBeveragesByCost
                .Take(firstN)
                .Sum(beverage => beverage.Cost);

            return result;
        }

        return _order.Cost;
    }

    public BuyTwoGetCheapestOneFreeOrderDecorator(IOrder order)
    {
        order = order ?? throw new ArgumentNullException(nameof(order), "Order cannot be null");
     
        _order = order;
    }
}