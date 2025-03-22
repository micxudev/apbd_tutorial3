using Tutorial3.enums;

namespace Tutorial3.containers;

public class RefrigeratedContainer : Container
{
    protected ProductType ProductType { get; set; }
    protected double TemperatureCelsius { get; set; }
    
    public override string Type => "C";

    public RefrigeratedContainer(double heightCm, double depthCm, double tareWeightKg, double maxPayloadKg,
        ProductType productType, double temperatureCelsius)
        : base(heightCm, depthCm, tareWeightKg, maxPayloadKg)
    {
        var requiredTemperature = ProductTypeExtensions.GetRequiredTemperature(productType);
        
        if (temperatureCelsius < requiredTemperature)
            throw new ArgumentException("Temperature cannot be lower than required by product");
        
        TemperatureCelsius = temperatureCelsius;
        ProductType = productType;
    }
    
    public override string ToString()
    {
        return base.ToString() + ",\n" +
               $"  ·ProductType {ProductType},\n" +
               $"  ·TemperatureCelsius {TemperatureCelsius}";
    }
}