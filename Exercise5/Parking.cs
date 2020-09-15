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
            //garage = handler.CreateGarage(10);  // TODO size is hardcoded
            //handler.PopulateWithTestData(garage);
        }
        private void MainMenu()
        {
            ui.PrintLine("Garage 1.0");
            do
            {
                ui.PrintLine("1 - Create new garage");
                ui.PrintLine("0 - Quit");
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

        // TODO Create garage menu
        // Add car menu
        // Add bus menu
        // Print stuff menus....
    }
}
