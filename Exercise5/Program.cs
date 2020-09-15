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


            Garage<Vehicle> vehicleGarage = new Garage<Vehicle>(10)
            {
                new Car("ABC123", "Blue", 4, FuelType.Gasoline),
                new Car("CDE123", "Blue", 4, FuelType.Gasoline),
                new Car("FGH123", "Blue", 4, FuelType.Gasoline)
            };

            foreach (var item in vehicleGarage)
            {
                Console.WriteLine(item?.ToString());
            }

            for (int i = 0; i < vehicleGarage.Capacity; i++)
            {
                if (vehicleGarage[i] == null)
                    Console.WriteLine($"{i}.\tFree space");
                else
                    Console.WriteLine($"{i}.\t{vehicleGarage[i]}");
            }

            var a1 = vehicleGarage.GetVehicle("abc123");
            Console.WriteLine(a1);
            var a2 = vehicleGarage.GetVehicle("vdskj");
            if (a2 == null) Console.WriteLine("NULL!!!");


        }
    }
}
