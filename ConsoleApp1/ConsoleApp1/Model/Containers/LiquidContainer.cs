namespace ConsoleApp1.Model.Containers;

public class LiquidContainer : ContainerBase
{
    public LiquidContainer(double height, double containerWeight, double depth, double maxWeight)
        : base(height, containerWeight, depth, maxWeight)
    {
        SerialNumber = "KON-L";
    }
}