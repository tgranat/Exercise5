using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {

            // flytta till klass motsvarande Game (namn?)
            // create Garage<Vehicle>

            // IVehicle (regnummer, färg, antalhjul)  Vehicle abstract class (regnummer, färg, antal hjul)

            // do 
            // main loop: 
            //   1. enter new vehicle   type? hur haneras det?
            //   2. se kravspec på sök
            //    3........n
            // while true

            // IHandler createVehicle
            // Vehicle v = GarageHandler.CreateVehicle()
            // GarageHandler.

            // en vehicle subklass måste få IUI så den kan ställa rätt frågor. vehicle subklass har
            // en loop och frågar dess specifika frågor mha IUI.GetInput och IUI.PreintMessage (om fel tex).

            GarageHandler h = new GarageHandler();
            Garage<IVehicle> vehicleGarage = h.CreateGarage(10);
            h.PopulateWithTestData(vehicleGarage);
            

            // Lista samtliga fordon (skriv inte ut tomma platser)
            foreach (var item in vehicleGarage)
            {
                if (item != null) Console.WriteLine(item.ToString());
            }

            vehicleGarage.RemoveVehicle("cde123");

            for (int i = 0; i < vehicleGarage.Capacity; i++)
            {
                if (vehicleGarage[i] == null)
                    Console.WriteLine($"{i}.\tFree space");
                else
                    Console.WriteLine($"{i}.\t{vehicleGarage[i]}");
            }
            vehicleGarage.Add(new Bus("BBB333", "Yellow", 6, 24));

            for (int i = 0; i < vehicleGarage.Capacity; i++)
            {
                if (vehicleGarage[i] == null)
                    Console.WriteLine($"{i}.\tFree space");
                else
                    Console.WriteLine($"{i}.\t{vehicleGarage[i]}");
            }
            //vehicleGarage.GetAllVehicles().ForEach(v => Console.WriteLine(v));




        }
    }
}
