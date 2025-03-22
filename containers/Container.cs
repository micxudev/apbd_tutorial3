using Tutorial3.exceptions;

namespace Tutorial3.containers;

public abstract class Container
{
    private static int _idCounter;
    public readonly int Id = ++_idCounter;
    protected double CargoMassKg { get; set; }
    public double HeightCm { get; }
    public double DepthCm { get; }
    public double TareWeightKg { get; }
    public double MaxPayloadKg { get; }
    public string SerialNumber => $"CON-{Type}-{Id}";
    public abstract string Type { get; } 
    
    protected Container(double heightCm, double depthCm, double tareWeightKg, double maxPayloadKg)
    {
        if (heightCm <= 0 || depthCm <= 0 || tareWeightKg <= 0 || maxPayloadKg <= 0)
            throw new ArgumentException("Container parameters must be positive");

        CargoMassKg = 0;
        HeightCm = heightCm;
        DepthCm = depthCm;
        TareWeightKg = tareWeightKg;
        MaxPayloadKg = maxPayloadKg;
    }

    public double TotalWeightKg()
    {
        return CargoMassKg + TareWeightKg;
    }

    public virtual void Load(double massKg)
    {
        if (massKg < 0)
            throw new ArgumentException("CargoMass cannot be negative");
        
        if (CargoMassKg + massKg > MaxPayloadKg)
            throw new OverfillException("Payload overfill");
        
        CargoMassKg += massKg;
    }
    
    public virtual void Unload()
    {
        CargoMassKg = 0;
    }

    public override string ToString()
    {
        return $"▸Container Info:\n" +
               $"  ·SerialNumber: {SerialNumber},\n" +
               $"  ·CargoMassKg: {CargoMassKg},\n" +
               $"  ·HeightCm: {HeightCm},\n" +
               $"  ·DepthCm: {DepthCm},\n" +
               $"  ·TareWeightKg: {TareWeightKg},\n" +
               $"  ·MaxPayloadKg: {MaxPayloadKg}";
    }
}