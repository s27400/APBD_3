// See https://aka.ms/new-console-template for more information

using ConsoleApp1.Model.Containers;
using ConsoleApp1.Model.Ship;

class Program
{
    public static void Main(string[] args)
    {
        List<Ship> Kontenerowce = new List<Ship>();
        List<ContainerBase> KonteneryWPorcie = new List<ContainerBase>();
        int choice = 0;
        Console.WriteLine(" ");
        while (true)
        {
            Console.WriteLine("Obecne statki:");
            foreach (Ship s in Kontenerowce)
            {
                Console.WriteLine(s.ToString());
            }
            Console.WriteLine(" ");

            Console.WriteLine("Obecne ładunki w porcie:");
            foreach (ContainerBase c in KonteneryWPorcie)
            {
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine(" ");

            
            Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("1. Dodaj kontenerowiec");
            Console.WriteLine("2. Usuń kontenerowiec");
            Console.WriteLine("3. Dodaj kontener");
            Console.WriteLine("4. Usuń kontener");
            Console.WriteLine("5. Działania na kontenerach");
            Console.WriteLine("6. Działania na statkach");
            Console.WriteLine();
            choice = Convert.ToInt32(Console.ReadLine());
            
            
            if (choice == 1)
            {
                Console.WriteLine("Podaj maksymalna predkosc (w wezlach)");
                double speed = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Podaj maksymalna ilosc kontenerow, ktore zmiesci statek");
                int max_con = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Podaj maksymalny udźwig statku (w tonach)");
                double max_ud = Convert.ToDouble(Console.ReadLine());
                Ship s = new Ship(speed, max_con, max_ud);
                Kontenerowce.Add(s);
            }
            
            else if (choice == 2)
            {
                Console.WriteLine("Podaj numer statku do usunięcia:");
                int counter = 0;
                foreach (Ship s in Kontenerowce)
                {
                    Console.WriteLine(counter + ". " + s);
                    counter++;
                }

                int toDel = Convert.ToInt32(Console.ReadLine());
                Kontenerowce.RemoveAt(toDel);
            }
            
            else if (choice == 3)
            {
                Console.WriteLine("Wybierz typ kontenerowca:");
                Console.WriteLine("1. Na płyny");
                Console.WriteLine("2. Na gaz");
                Console.WriteLine("3. Chłodniczy");
                int choiceCon = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Podaj wysokosc (w cm)");
                double wys = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Podaj wage samego kontenera (w kg)");
                double samCon = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Podaj głębokość (w cm)");
                double dpt = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Podaj maksymalną ładowność (w kg)");
                double max_lad = Convert.ToDouble(Console.ReadLine());
                if (choiceCon == 1)
                {
                    LiquidContainer l = new LiquidContainer(wys, samCon, dpt, max_lad);
                    KonteneryWPorcie.Add(l);
                }else if (choiceCon == 2)
                {
                    Console.WriteLine("Podaj ciśnienie (w atmosferach");
                    double pres = Convert.ToDouble(Console.ReadLine());
                    GasContainer g = new GasContainer(wys, samCon, dpt, max_lad, pres);
                    KonteneryWPorcie.Add(g);
                }else if (choiceCon == 3)
                {
                    Console.WriteLine("Podaj temperature");
                    double temp = Convert.ToDouble(Console.ReadLine());
                    CoolContainer c = new CoolContainer(wys, samCon, dpt, max_lad, temp);
                    KonteneryWPorcie.Add(c);
                }
            }
            
            else if (choice == 4)
            {
                Console.WriteLine("Podaj numer kontenera do usunięcia:");
                int counter = 0;
                foreach (ContainerBase c in KonteneryWPorcie)
                {
                    Console.WriteLine(counter + ". " + c.ToString());
                    counter++;
                }

                int toDel = Convert.ToInt32(Console.ReadLine());
                KonteneryWPorcie.RemoveAt(toDel);
            }
            
            else if (choice == 5)
            {
                Console.WriteLine("Podaj numer kontenera:");
                int counter = 0;
                foreach (ContainerBase temp in KonteneryWPorcie)
                {
                    Console.WriteLine(counter + ". " + temp.ToString());
                    counter++;
                }
                int toTake = Convert.ToInt32(Console.ReadLine());
                
                
                Console.WriteLine("Podaj numer akcji:");
                Console.WriteLine("1. Załaduj kontener");
                Console.WriteLine("2. Rozładuj kontener");
                int choiceCon = Convert.ToInt32(Console.ReadLine());
                if (choiceCon == 2)
                {
                    KonteneryWPorcie.ElementAt(toTake).Unpack();
                }else if (choiceCon == 1)
                {
                    Console.WriteLine("Podaj masę do załadunku:");
                    double toLoad = Convert.ToDouble(Console.ReadLine());
                    KonteneryWPorcie.ElementAt(toTake).Pack(toLoad);
                }
            }
            
            else if (choice == 6)
            {
                Console.WriteLine("Podaj numer statku:");
                int counter = 0;
                foreach (Ship temp in Kontenerowce)
                {
                    Console.WriteLine(counter + ". " + temp.ToString());
                    counter++;
                }
                int toTake = Convert.ToInt32(Console.ReadLine());
                Kontenerowce.ElementAt(toTake);
                Console.WriteLine("Podaj numer akcji:");
                Console.WriteLine("1. Załaduj kontener na statek");
                Console.WriteLine("2. Załaduj listę koneterów na statek");
                Console.WriteLine("3. Usuniecie kontenera ze statku");
                Console.WriteLine("4. Zamiana kontenera na statku z innym");
                Console.WriteLine("5. Przeniesienie kontenera miedzy statkami");
                Console.WriteLine("6. Wypisanie informacji o statku i ładunku");
                int choiceShip = Convert.ToInt32(Console.ReadLine());
                if (choiceShip == 1)
                {
                    Console.WriteLine("Podaj numer kontenerów:");
                    int c2 = 0;
                    foreach (ContainerBase temp in KonteneryWPorcie)
                    {
                        Console.WriteLine(c2 + ". " + temp.ToString());
                        c2++;
                    }
                    int toAdd = Convert.ToInt32(Console.ReadLine());
                    if (Kontenerowce.ElementAt(toTake).loadContainer(KonteneryWPorcie.ElementAt(toAdd)))
                    {
                        KonteneryWPorcie.RemoveAt(toAdd);
                    };
                }
                
                else if (choiceShip == 2)
                {
                    List<ContainerBase> temporaryL = new List<ContainerBase>();
                    int choice_2 = -1;
                    
                        while (choice_2 != -2)
                        {
                            Console.WriteLine("Podaj numery kontenerów: (-2 koniec)");
                            int c2 = 0;
                            foreach (ContainerBase temp in KonteneryWPorcie)
                            {
                                Console.WriteLine(c2 + ". " + temp);
                                c2++;
                            }
                            temporaryL.Add(KonteneryWPorcie.ElementAt(choice_2));
                            KonteneryWPorcie.RemoveAt(choice_2);
                        }
                        
                        Kontenerowce.ElementAt(toTake).loadListContainer(temporaryL);

                        foreach (ContainerBase c in temporaryL)
                        {
                            KonteneryWPorcie.Add(c);
                        }
                        temporaryL.Clear();
                }
                else if (choiceShip == 3)
                {
                    ContainerBase c = Kontenerowce.ElementAt(toTake).unloadContainer();
                    KonteneryWPorcie.Add(c);
                }
                else if (choiceShip == 4)
                {
                    ContainerBase c = Kontenerowce.ElementAt(toTake).unloadContainer();
                    KonteneryWPorcie.Add(c);
                    Console.WriteLine("Podaj numer konteneru do zaladowania:");
                    int c2 = 0;
                    foreach (ContainerBase temp in KonteneryWPorcie)
                    {
                        Console.WriteLine(c2 + ". " + temp.ToString());
                        c2++;
                    }
                    int toAdd = Convert.ToInt32(Console.ReadLine());
                    if (Kontenerowce.ElementAt(toTake).loadContainer(KonteneryWPorcie.ElementAt(toAdd)))
                    {
                        KonteneryWPorcie.RemoveAt(toAdd);
                    };
                }
                else if (choiceShip == 5)
                {
                    ContainerBase c = Kontenerowce.ElementAt(toTake).unloadContainer();
                    Console.WriteLine("Na ktory statek chcesz go zaladowac");
                    Console.WriteLine("Podaj numer statku:");
                    int c_2 = 0;
                    foreach (Ship temp in Kontenerowce)
                    {
                        Console.WriteLine(c_2 + ". " + temp.ToString());
                        c_2++;
                    }
                    int choice_2 = Convert.ToInt32(Console.ReadLine());
                    if (Kontenerowce.ElementAt(choice_2).loadContainer(c))
                    {
                        Console.WriteLine("Przeladowalem kontener na statek: " + Kontenerowce.ElementAt(choice_2));
                    }
                    else
                    {
                        Console.WriteLine("Przeladowalem kontener do portu: ");
                    };
                }
                else if (choiceShip == 6)
                {
                    Console.WriteLine(Kontenerowce.ElementAt(toTake));
                    Console.WriteLine("Załadunek");
                    foreach (ContainerBase cont in Kontenerowce.ElementAt(toTake).ContainersOnShip)
                    {
                        Console.WriteLine(cont);
                    }
                }
            }
            else
            {
                break;
            }

        }
    }
}