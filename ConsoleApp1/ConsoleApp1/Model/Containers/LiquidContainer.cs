
using ConsoleApp1.Model.Exception;
using ConsoleApp1.Model.Interface;

namespace ConsoleApp1.Model.Containers;



public class LiquidContainer : ContainerBase, IHazardNotifier
{

    protected string Load { get; set; }
    protected Boolean ContainsHazard { get; set; }
    public LiquidContainer(double height, double containerWeight, double depth, double maxWeight)
        : base(height, containerWeight, depth, maxWeight)
    {
        SerialNumber = "KON-L-"+this.Id;
        Load = "";
        this.ContainsHazard = false;
    }

    public override void Pack(double packageWeight)
    {
        try
        {
            base.Pack(packageWeight);
            Console.WriteLine("Co chcesz załadować:");
                    Console.WriteLine("1. Paliwo");
                    Console.WriteLine("2. Mleko");
            
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        this.Load = "Paliwo";
                    }
                    else
                    {
                        this.Load = "Mleko";
                    }
            
                    if (this.Load.Equals("Paliwo"))
                    {
                        this.ContainsHazard = true;
                    }
                    if (this.ContainsHazard)
                    {
                        if (this.CurrentWeight + packageWeight > MaxWeight / 2)
                        {
                            IHazardNotifier.NotifyDanger("za duża waga przy niebezpiecznym ładunku");
                            this.Load = "";
                        }
                        else
                        {
                            this.CurrentWeight = this.CurrentWeight + packageWeight;
                            Console.WriteLine("Załadowano kontener : " + this.Load);
                        }
                    }
                    else
                    {
                        if (this.CurrentWeight + packageWeight > (MaxWeight / 10)*9)
                        {
                            IHazardNotifier.NotifyDanger(" za duża waga przy bezpiecznym ładunku");
                            this.Load = "";
                        }
                        else
                        {
                            this.CurrentWeight = this.CurrentWeight + packageWeight;
                            Console.WriteLine("Załadowano kontener : " + this.Load);
                        }
                    }
                    if (this.Load.Equals("Paliwo"))
                    {
                        this.ContainsHazard = true;
                    }
                    else
                    {
                        this.ContainsHazard = false;
                    }
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e);
        }
    }

    public override void Unpack()
    {
        base.Unpack();
        this.Load = "";
        Console.WriteLine("Wypakowano kontener " + this.SerialNumber);
    }
    
    public override string ToString()
    {
        return this.SerialNumber + " wysokość: " + this.Height + " waga samego kontenetra: " + this.ContainerWeight + " głębokość " + this.Depth + " Maksymalna waga ładunku: " + this.MaxWeight + " zawartość: " + this.Load + " Obecna waga zawartości: " + this.CurrentWeight;
    }
    
}