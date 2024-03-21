using ConsoleApp1.Model.Exception;

namespace ConsoleApp1.Model.Containers;

public class CoolContainer : ContainerBase
{
    protected List<string> Products = new List<string>() { "Bananas;13,3", "Chocolate;18", "Fish;2", "Meat;-15", "Ice cream;-18", {"Frozen pizza;-30"}, {"Cheese;7,2"}, {"Sausages;5"},{"Butter;20,5"}, {"Eggs;19"} };
    
    protected double Temperature { get; set; }
    protected string Inside { get; set; }
    public CoolContainer(double height, double containerWeight, double depth, double maxWeight, double temp)
        : base(height, containerWeight, depth, maxWeight)
    {
        SerialNumber = "KON-C-"+this.Id;
        this.Temperature = temp;
        this.Inside = "";

    }

    public override void Pack(double packageWeight)
    {
        try
        {
            base.Pack(packageWeight);
            List<string> temp = new List<string>();
            foreach (string str in Products)
            {
                string[] strings = str.Split(";");
                if (Convert.ToDouble(strings[1]) > this.Temperature)
                {
                    temp.Add(strings[0]);
                }
            }
            Console.WriteLine("Podaj liczbę: ");
            int counter = 0;
            foreach (string s in temp)
            {
                Console.WriteLine(counter + " " + s);
                counter++;
            }

            int userCh = Convert.ToInt32(Console.ReadLine());
            this.Inside = temp.ElementAt(userCh);
            this.CurrentWeight = this.CurrentWeight + packageWeight;
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e);
        }
        
    }

    public override void Unpack()
    {
        base.Unpack();
        this.Inside = "";
        Console.WriteLine("Rozpakowałem kontener : " + this.SerialNumber);
    }

    public override string ToString()
    {
        return this.SerialNumber + " Wysokość: " + this.Height + " Waga samego kontenera: " + this.ContainerWeight + " Głębokość " + this.Depth + " Maksymalna waga ładunku: " + this.MaxWeight + " Obecna waga zawartości: " + this.CurrentWeight + " Temperatura: " + this.Temperature + " Zawartość: " + this.Inside;
    }
}