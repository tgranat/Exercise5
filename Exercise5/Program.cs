using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            Parking parking = new Parking();
            parking.Run();

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

            //GarageHandler h = new GarageHandler();
            //Garage<IVehicle> vehicleGarage = h.CreateGarage(10);
            //h.PopulateWithTestData(vehicleGarage);

            //h.CreateCar(vehicleGarage, "KJ8787897", "Blue", 4, FuelType.Gasoline);
            //// Lista samtliga fordon (skriv inte ut tomma platser)
            //foreach (var item in vehicleGarage)
            //{
            //    if (item != null) Console.WriteLine(item.ToString());
            //}

            //vehicleGarage.RemoveVehicle("cde123");
            //// samma som
            //h.RemoveVehicle(vehicleGarage, "cde123");

            //for (int i = 0; i < vehicleGarage.Capacity; i++)
            //{
            //    if (vehicleGarage[i] == null)
            //        Console.WriteLine($"{i}.\tFree space");
            //    else
            //        Console.WriteLine($"{i}.\t{vehicleGarage[i]}");
            //}
            //Console.WriteLine(  vehicleGarage.Add(new Bus("BBB333", "Yellow", 6, 24)));

            //h.GetParkingSpaceData(vehicleGarage).ForEach(v => Console.WriteLine(v));
            //h.GetParkedVehicles(vehicleGarage).ForEach(v => Console.WriteLine(v));


            ////for (int i = 0; i < vehicleGarage.Capacity; i++)
            ////{
            ////    if (vehicleGarage[i] == null)
            ////        Console.WriteLine($"{i}.\tFree space");
            ////    else
            ////        Console.WriteLine($"{i}.\t{vehicleGarage[i]}");
            ////}
            ////vehicleGarage.GetAllVehicles().ForEach(v => Console.WriteLine(v));

            //Console.WriteLine("Blue vehicles:");
            //h.GetVehicles(vehicleGarage, "Blue").ForEach(v => Console.WriteLine(v));
            //vehicleGarage.GetVehicles("blue").ForEach(v => Console.WriteLine(v));
            //Console.WriteLine("Red vehicles (none):");
            //h.GetVehicles(vehicleGarage, "red").ForEach(v => Console.WriteLine(v));

        }
    }
}
