using ConsoleApp1.Model.Containers;

namespace ConsoleApp1.Model.Ship;

public class Ship
{
    public List<ContainerBase> ContainersOnShip { get; set; }
    protected double MaxSpeed { get; set; }
    protected int ContainersMaxAmount { get; set; }
    protected double ContainersMaxWeight { get; set; }
    
    protected double ShipCurrnetWeight { get; set; }
    protected double ShipCurrnetAmount { get; set; }

    public Ship(double maxSpeed, int containersMaxAmount, double containersMaxWeight)
    {
        this.ContainersOnShip = new List<ContainerBase>();
        this.MaxSpeed = maxSpeed;
        this.ContainersMaxWeight = containersMaxWeight;
        this.ContainersMaxAmount = containersMaxAmount;
        this.ShipCurrnetAmount = 0;
        this.ShipCurrnetWeight = 0;
    }

    public Boolean loadContainer(ContainerBase cont)
    {
        if (this.ShipCurrnetAmount+1 <= this.ContainersMaxAmount)
        {
            if (this.ShipCurrnetWeight + (cont.CurrentWeight/1000 + cont.ContainerWeight/1000) <= this.ContainersMaxWeight)
            {
                this.ContainersOnShip.Add(cont);
                this.ShipCurrnetWeight = this.ShipCurrnetWeight + (cont.CurrentWeight/1000 + cont.ContainerWeight/1000);
                this.ShipCurrnetAmount++;
                Console.WriteLine("Kontener zapakowany " + cont);
                return true;
            }
            else
            {
                Console.WriteLine("Nie mogę zapakować tego kontenera: za duża masa");
            }
        }
        else
        {
            Console.WriteLine("Nie mogę zapakować tego kontenera: za dużo koneterów");
        }

        return false;
    }

    public void loadListContainer(List<ContainerBase> list)
    {
        foreach(ContainerBase cont in list)
        {
            if (this.loadContainer(cont))
            {
                list.Remove(cont);
            }
        }
    }

    public ContainerBase unloadContainer()
    {
        int counter = 0;
        Console.WriteLine("Podaj numer do usuniecia:");
        foreach (ContainerBase c in this.ContainersOnShip)
        {
            Console.WriteLine(counter + " " + c);
            counter++;
        }

        int choice = Convert.ToInt32(Console.ReadLine());
        ContainerBase res = ContainersOnShip.ElementAt(choice);
        this.ContainersOnShip.RemoveAt(choice);
        double temp = (res.CurrentWeight / 1000) + (res.ContainerWeight / 1000);
        this.ShipCurrnetWeight = this.ShipCurrnetWeight - temp ;
        this.ShipCurrnetAmount--;
        return res;
    }

    public void showLoad()
    {
        foreach (ContainerBase c in ContainersOnShip)
        {
            Console.WriteLine(c);
        }
    }


    public override string ToString()
    {
        return "Statek maksymalna prędkość: " + this.MaxSpeed + " max ilość: " + this.ContainersMaxAmount + " max waga: " +
               this.ContainersMaxWeight + " obecna ilosc: " + this.ShipCurrnetAmount + " obecna waga: " +
               this.ShipCurrnetWeight;
    }
}