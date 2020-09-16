using System;
using System.Collections.Generic;
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
            //handler.PopulateWithTestData(garage);
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

            //handler.PopulateWithTestData(garage);
            //garage.NumberOfVehicles().ForEach(x => Console.WriteLine(x));
            //handler.GetNumberOfVehicles(garage).ForEach(v => ui.PrintLine(v));
        }

        private void VehiclesManagement()
        {
            ui.PrintLine("Manage vehicles");
            do
            {
                ui.PrintLine("0 - Quit");
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
                        CreateGarage();
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
        private void GarageSearch()
        {
            ui.PrintLine("Search and list in garage");
            do
            {
                ui.PrintLine("0 - Quit");
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
