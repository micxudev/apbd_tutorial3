using Tutorial3.containers;
using Tutorial3.exceptions;

namespace Tutorial3.vehicles;

public abstract class Vehicle
{
    public List<Container> Containers { get; }
    public double MaxSpeed { get; }
    public int MaxContainers { get; }
    public int MaxContainersWeightTons { get; }

    protected Vehicle(double maxSpeed, int maxContainers, int maxContainersWeightTons)
    {
        if (maxSpeed <= 0 || maxContainers <= 0 || maxContainersWeightTons <= 0)
            throw new ArgumentException("Vehicle parameters must be positive");

        Containers = new List<Container>(maxContainers);
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxContainersWeightTons = maxContainersWeightTons;
    }
    
    public bool AddContainer(Container container)
    {
        if (Containers.Count >= MaxContainers) 
            return false;
        
        if (CurrentWeight() + container.TotalWeightKg() > MaxContainersWeightTons * 1000)
           return false;
        
        Containers.Add(container);
        return true;
    }

    private double CurrentWeight()
    {
        double totalWeight = 0;
        foreach (var container in Containers)
            totalWeight += container.TotalWeightKg();
        return totalWeight;
    }

    public bool AddContainers(List<Container> containers)
    {
        foreach (var container in containers)
            if (!AddContainer(container)) return false;
        return true;
    }

    public bool RemoveContainer(Container container)
    {
        return Containers.Remove(container);
    }

    public bool ReplaceContainer(int idToReplace, Container replaceWith)
    {
        for (var i = 0; i < Containers.Count; i++)
        {
            if (Containers[i].Id == idToReplace)
            {
                Containers[i] = replaceWith;
                return true;
            }
        }
        return false;
    }

    public static bool TransferContainer(Container container, Vehicle from, Vehicle to)
    {
        if (!to.AddContainer(container)) 
            return false;

        if (!from.RemoveContainer(container))
        {
            to.RemoveContainer(container);
            return false;
        }
        
        return true;
    }

    public override string ToString()
    {
        return $"▸Vehicle Info:\n" +
               $"  ·MaxSpeed: {MaxSpeed},\n" +
               $"  ·MaxContainers: {MaxContainers},\n" +
               $"  ·MaxContainersWeightTons: {MaxContainersWeightTons}\n" +
               $" ▸Containers:\n\n{string.Join("\n\n", Containers)}";
    }
}