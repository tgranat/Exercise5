using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise5
{
    public class GarageMenu
    {
  
        // TODO extract handler interface
        private GarageHandler handler;
        private Garage<IVehicle> garage;
        private IUI ui;  

        public void Run()
        {
            Initialize();
            MainMenu();
        }

        private void Initialize()
        {
            ui = new UI(); 
            handler = new GarageHandler();
            // Creates a default garage
            garage = handler.CreateGarage(10); 
         }
        private void MainMenu()
        {
            ui.PrintLine("Garage 1.0");
            do
            {
                ui.PrintLine("0 - Quit");
                ui.PrintLine("1 - Create new garage");
                ui.PrintLine("2 - Manage vehicles (add, remove, display info)"); 
                ui.PrintLine("3 - Searches (list and search in garage)");
                ui.PrintLine("4 - Populate garage with testdata");

                int choice = ui.ReadInt();
               
                switch (choice)
                {
                    case 1:
                        CreateGarage();
                        break;
                    case 2:
                        VehiclesManagement();
                        break;
                    case 3:
                        GarageSearch();
                        break;
                    case 4:
                        handler.PopulateWithTestData(garage);
                        ui.PrintLine("Garage has been populated with test data");
                        break;
                    case 0:
                        ui.PrintLine("Exiting.");
                        return;
                        
                    default:
                        ui.PrintLine("Please enter a valid input.");
                        break;
                }
            }
            while (true);
        }


        private void CreateGarage()
        {
            int capacity = ui.ReadInt("Enter capacity of the garage: ");
            garage = handler.CreateGarage(capacity);
            ui.PrintLine($"New garage created with capacity: {capacity}");
        }

        private void VehiclesManagement()
        {
            ui.PrintLine("Manage vehicles");
            do
            {
                ui.PrintLine("0 - Back to main menu");
                ui.PrintLine("1 - Add a car"); 
                ui.PrintLine("2 - Add a bus");
                ui.PrintLine("3 - Add a motorcycle");
                ui.PrintLine("4 - Add a boat");
                ui.PrintLine("5 - Add an airplane");
                ui.PrintLine("6 - Display vehicle based on registration number");
                ui.PrintLine("7 - Remove a vehicle based on registration number");

                int choice = ui.ReadInt();
               
                switch (choice)
                {
                    case 1:
                        AddCar();
                        break;
                    case 2:
                        AddBus();
                        break;
                    case 3:
                        // TODO
                        ui.PrintLine("Not implemented");
                        break;
                    case 4:
                        // TODO
                        ui.PrintLine("Not implemented");
                        break;
                    case 5:
                        // TODO
                        ui.PrintLine("Not implemented");
                        break;
                    case 6:
                        // TODO
                        ui.PrintLine("Not implemented");
                        break;
                    case 7:
                        // TODO
                        ui.PrintLine("Not implemented");
                        break;
                    case 0:
                        ui.PrintLine("Exiting mangage vehicles.");
                        return;

                    default:
                        ui.PrintLine("Please enter a valid input.");
                        break;
                }
            }
            while (true);
        }

        private void AddCar()
        { 
            if (handler.IsGarageFull(garage))
            {
                ui.PrintLine("Garage is full!");
                return;
            }
            var (regNumber, color, wheels) = GetBasicVehicleInfo();
            
            ui.PrintLine("Enter fuel type (enter digit)");
            foreach (var enumValue in Enum.GetValues(typeof(FuelType)))
            {
                ui.PrintLine($"{(int)enumValue} - {enumValue}");
            }
            // Thank you Stackoverflow
            int fuel = ui.ReadInt(
                Enum.GetValues(typeof(FuelType)).Cast<int>().Min(),
                Enum.GetValues(typeof(FuelType)).Cast<int>().Max());

            if (handler.IsVehicleParked(garage, regNumber))
            {
                ui.PrintLine($"Vehicle wirh registration number {regNumber} is already parked.");
                return;
            }
            bool success = handler.CreateCar(garage, regNumber, color, wheels, (FuelType)fuel);
            if (!success)
            {
                ui.PrintLine("Failed to add car.");
                return;
            }
            ui.PrintLine("Successfully added car.");
        }

        private void AddBus()
        {
            if (handler.IsGarageFull(garage))
            {
                ui.PrintLine("Garage is full!");
                return;
            }
            var (regNumber, color, wheels) = GetBasicVehicleInfo();

            int seats = ui.ReadInt("Enter number of seats: ");

            if (handler.IsVehicleParked(garage, regNumber))
            {
                ui.PrintLine($"Vehicle with registration number {regNumber} is already parked.");
                return;
            }
            bool success = handler.CreateBus(garage, regNumber, color, wheels, seats);
            if (!success)
            {
                ui.PrintLine("Failed to add car.");
                return;
            }
            ui.PrintLine("Successfully added bus.");
        }

        private (string regNumber, string color, int wheels) GetBasicVehicleInfo()
        {
            string regNumber = ui.ReadLine("Enter registration number: ");
            string color = ui.ReadLine("Enter color: ");
            int wheels = ui.ReadInt("Enter number of wheels: ");
            return (regNumber, color, wheels);
        }

        private void GarageSearch()
        {
            ui.PrintLine("Search and list in garage");
            do
            {
                ui.PrintLine("0 - Back to main menu");
                ui.PrintLine("1 - List all vehicles");
                ui.PrintLine("2 - List all parking spaces and vehicles");
                ui.PrintLine("3 - List number of vehicle types");
                ui.PrintLine("3 - List vehicles based on color");
                ui.PrintLine("4 - List vehicles based on type");
                ui.PrintLine("5 - List vehicles based on type, color and number of wheels"); // TODO how to do this better more dynamic??

                int choice = ui.ReadInt();

                switch (choice)
                {
                    case 1:
                        ui.PrintLine("Parked vehicles:");
                        handler.GetParkedVehicles(garage).ForEach(i => ui.PrintLine(i));
                        break;
                    case 2:
                        ui.PrintLine("Parking spaces:");
                        handler.GetParkingSpaceData(garage).ForEach(i => ui.PrintLine(i));
                        break;
                    case 3:
                        ui.PrintLine("Number of vehicle types:");
                        handler.GetNumberOfVehicles(garage).ForEach(i => ui.PrintLine(i));
                        break;
                    case 4:
                        // TODO
                        ui.PrintLine("Not implemented");
                        break;
                    case 5:
                        // TODO
                        ui.PrintLine("Not implemented");
                        break;
                    case 0:
                        ui.PrintLine("Exiting search and list.");
                        return;
                    default:
                        ui.PrintLine("Please enter a valid input.");
                        break;
                }
            }
            while (true);
        }
   
    }
}
