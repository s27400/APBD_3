namespace ConsoleApp1.Model.Containers;

public abstract class ContainerBase
{
    protected double CurrentWeight { get; set; }
    protected double Height { get; }
    protected double ContainerWeight { get; }
    protected double Depth { get; }
    protected string SerialNumber { get; set; }
    protected double MaxWeight { get;  }
    protected int Id { get; }
    protected static int Counter = 1;

    protected ContainerBase(double height, double containerWeight, double depth, double maxWeight)
    {
        CurrentWeight = 0;
        Height = height;
        ContainerWeight = containerWeight;
        Depth = depth;
        SerialNumber = " ";
        Id = Counter;
        Counter = Counter + 1;
        MaxWeight = maxWeight;
    }

    protected void Pack(double PackageWeight)
    {
        this.CurrentWeight = this.CurrentWeight + PackageWeight;
    }

    protected void Unpack()
    {
        this.CurrentWeight = 0;
    }
}