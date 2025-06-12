namespace CoffeeProducts.Products
{
    public interface IBeverage
    {
        decimal Cost { get; }
        string? Description { get; }
    }
}
