using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    public class Parking
    {
        // IUI

        // TODO extract handler interface
        private GarageHandler handler;
        private Garage<IVehicle> garage;
        private UI ui;   // TODO will be an interfacae

        public void Run()
        {
            Initialize();
            MainMenu();
        }

        private void Initialize()
        {
            ui = new UI();  // TODO will be interface
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
                ui.PrintLine("1 - Add a car"); // TODO move to "Add a vehicle" and go to separate menu
                ui.PrintLine("2 - Add a bus");
                ui.PrintLine("3 - Add a motorcycle");
                ui.PrintLine("4 - Add a boat");
                ui.PrintLine("5 - Add an airplane");
                ui.PrintLine("6 - Display vehicle based on registration number");
                ui.PrintLine("7 - Remove a vehicle based on registration number");
                ui.PrintLine("8 - List all vehicles");
                ui.PrintLine("9 - List all parking spaces and vehicles"); // TODO move to "Special searches" menu
                ui.PrintLine("10- List number of vehicle types");
                
                int choice = ui.ReadInt();
                // TODO switch
                switch (choice)
                {
                    case 1:
                        CreateGarage();
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
        }


        // Add car menu
        // Add bus menu
        // Print stuff menus....
    }
}
