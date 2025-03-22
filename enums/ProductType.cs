namespace Tutorial3.enums;

public enum ProductType
{
    Bananas,
    Chocolate,
    Fish,
    Meat,
    IceCream,
    FrozenPizza,
    Cheese,
    Sausages,
    Butter,
    Eggs
}

public static class ProductTypeExtensions
{
    public static double GetRequiredTemperature(ProductType productType)
    {
        return productType switch
        {
            ProductType.Bananas => 13.3,
            ProductType.Chocolate => 18,
            ProductType.Fish => 2,
            ProductType.Meat => -15,
            ProductType.IceCream => -18,
            ProductType.FrozenPizza => -30,
            ProductType.Cheese => 7.2,
            ProductType.Sausages => 5,
            ProductType.Butter => 20.5,
            ProductType.Eggs => 19,
            _ => throw new ArgumentException("Invalid product type")
        };
    }
}