using Tutorial3.exceptions;
using Tutorial3.interfaces;

namespace Tutorial3.containers;

public class GasContainer(double heightCm, double depthCm, double tareWeightKg, double maxPayloadKg,
    double pressureAtm)
    : Container(heightCm, depthCm, tareWeightKg, maxPayloadKg), IHazardNotifier
{
    protected double PressureAtm { get; set; } = pressureAtm;
    
    public override string Type => "G";

    public override void Load(double massKg)
    {
        if (massKg < 0)
            throw new ArgumentException("CargoMass cannot be negative");

        if (CargoMassKg + massKg > MaxPayloadKg)
        {
            NotifyHazard("Hazardous event occured");
            throw new OverfillException("Payload overfill");
        }
        
        CargoMassKg += massKg;
    }
    
    public override void Unload()
    {
        CargoMassKg *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"{SerialNumber} : {message}");
    }

    public override string ToString()
    {
        return base.ToString() + ",\n" +
               $"  ·PressureAtm {PressureAtm:F2}";
    }
}