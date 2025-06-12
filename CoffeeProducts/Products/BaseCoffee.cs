namespace CoffeeProducts.Products;

public class BaseCoffee : IBeverage
{
    public decimal Cost => 0.10m; // Base cost for small coffee
    public string Description => "Coffee"; // Base description
}
