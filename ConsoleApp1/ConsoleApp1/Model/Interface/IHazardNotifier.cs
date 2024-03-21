namespace ConsoleApp1.Model.Interface;

public interface IHazardNotifier
{
    static void NotifyDanger(string str)
    {
        Console.WriteLine("Niebezpieczna sytuacja z kontenerem " + str);   
    }
}