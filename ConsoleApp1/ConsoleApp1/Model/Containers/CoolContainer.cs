namespace ConsoleApp1.Model.Containers;

public class CoolContainer : ContainerBase
{
    public CoolContainer(double height, double containerWeight, double depth, double maxWeight)
        : base(height, containerWeight, depth, maxWeight)
    {
        SerialNumber = "KON-C-"+this.Id;
    }
}