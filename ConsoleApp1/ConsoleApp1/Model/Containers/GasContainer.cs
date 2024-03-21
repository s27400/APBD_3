
using ConsoleApp1.Model.Exception;
using ConsoleApp1.Model.Interface;

namespace ConsoleApp1.Model.Containers;

public class GasContainer : ContainerBase, IHazardNotifier
{
    protected double AtmosphericPressure { get; set; }
    protected Boolean HighRisk { get; set; }
    public GasContainer(double height, double containerWeight, double depth, double maxWeight, double pressure)
        : base(height, containerWeight, depth, maxWeight)
    {
        SerialNumber = "KON-G-"+this.Id;
        this.AtmosphericPressure = pressure;
        if (pressure > 10)
        {
            this.HighRisk = true;
        }
        else
        {
            this.HighRisk = false;
        }
    }

    
    public override void Pack(double packageWeight)
    {
        try
        {
            if (this.HighRisk)
            {
                IHazardNotifier.NotifyDanger(this.SerialNumber);
            }

            base.Pack(packageWeight);
            this.CurrentWeight = this.CurrentWeight + packageWeight;
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e);
        }
    }
    

    public override void Unpack()
    {
        if (this.HighRisk)
        {
            IHazardNotifier.NotifyDanger(this.SerialNumber);
        }
        this.CurrentWeight = this.CurrentWeight * 0.05;
        Console.WriteLine("Rozpakowałem " + this.SerialNumber);
    }
    
    public override string ToString()
    {
        return this.SerialNumber + " wysokosc: " + this.Height + " waga samego kontenera: " + this.ContainerWeight + " glebokosc: " + this.Depth + " Maksymalna waga ładunku: " + this.MaxWeight + " cisnienie: " + this.AtmosphericPressure +  " Obecna waga zawartości: " + this.CurrentWeight + " wysokie ryzyko: " + this.HighRisk;
    }
}