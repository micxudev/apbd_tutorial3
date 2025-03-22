using Tutorial3.exceptions;
using Tutorial3.interfaces;

namespace Tutorial3.containers;

public class LiquidContainer(double heightCm, double depthCm, double tareWeightKg, double maxPayloadKg,
    bool isHazardous)
    : Container(heightCm, depthCm, tareWeightKg, maxPayloadKg), IHazardNotifier
{
    protected bool IsHazardous { get; set; } = isHazardous;
    
    private double MaxAllowedPayloadKg => IsHazardous ? 0.5 * MaxPayloadKg : 0.9 * MaxPayloadKg;
    public override string Type => "L";
    
    public override void Load(double massKg)
    {
        if (massKg < 0)
            throw new ArgumentException("CargoMass cannot be negative");

        if (CargoMassKg + massKg > MaxAllowedPayloadKg)
        {
            NotifyHazard("Prevented dangerous operation");
            throw new OverfillException("Payload overfill");
        }
        
        CargoMassKg += massKg;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"{SerialNumber} : {message}");
    }

    public override string ToString()
    {
        return base.ToString() + ",\n" +
               $"  ·IsHazardous: {IsHazardous}";
    }
}