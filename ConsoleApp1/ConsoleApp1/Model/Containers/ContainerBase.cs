using ConsoleApp1.Model.Exception;

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

    protected void Pack(double packageWeight)
    {
        if (this.CurrentWeight + packageWeight > this.MaxWeight)
        {
            this.CurrentWeight = this.CurrentWeight + packageWeight;
        }
        else
        {
            throw new OverfillException("Ładunek przekroczył dopuszczalny limit");
        }
    }

    protected void Unpack()
    {
        this.CurrentWeight = 0;
    }
}