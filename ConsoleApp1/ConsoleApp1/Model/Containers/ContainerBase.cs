namespace ConsoleApp1.Model.Containers;

public abstract class ContainerBase
{
    protected double CurrentWeight { get; set; }
    protected double Height { get; }
    protected double ContainerWeight { get; }
    protected double Depth { get; }
    protected string SerialNumber { get; set; }
    protected double MaxWeight { get;  }

    protected ContainerBase(double height, double containerWeight, double depth, double maxWeight)
    {
        CurrentWeight = 0;
        Height = height;
        ContainerWeight = containerWeight;
        Depth = depth;
        SerialNumber = "KON-";
        MaxWeight = maxWeight;

    }
}