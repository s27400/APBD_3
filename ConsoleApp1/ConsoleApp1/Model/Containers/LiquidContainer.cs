using ConsoleApp1.Model.Interface;

namespace ConsoleApp1.Model.Containers;

public class LiquidContainer : ContainerBase, IHazardNotifier
{
    public LiquidContainer(double height, double containerWeight, double depth, double maxWeight)
        : base(height, containerWeight, depth, maxWeight)
    {
        SerialNumber = "KON-L-"+this.Id;
    }

    public void isDangerous()
    {
        
    }
}