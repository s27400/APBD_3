namespace ConsoleApp1.Model.Containers;

public class GasContainer : ContainerBase
{
    public GasContainer(double height, double containerWeight, double depth, double maxWeight)
        : base(height, containerWeight, depth, maxWeight)
    {
        SerialNumber = "KON-G";
    }
}