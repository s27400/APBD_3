using ConsoleApp1.Model.Exception;

namespace ConsoleApp1.Model.Containers;

public class ContainerBase
{
    public double CurrentWeight { get; set; }
    protected double Height { get; }
    public double ContainerWeight { get; }
    protected double Depth { get; }
    public string SerialNumber { get; set; }
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

    public virtual void Pack(double packageWeight)
    {
        if (this.CurrentWeight + packageWeight > this.MaxWeight)
        {
            throw new OverfillException("Ładunek przekroczył dopuszczalny limit");
        }
    }
    
    public virtual void Unpack()
    {
        this.CurrentWeight = 0;
    }
}