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
            // create IUI
            Initialize();
            Menu();
        }

        private void Initialize()
        {
            ui = new UI();  
            handler = new GarageHandler();
            garage = handler.CreateGarage(10);  // TODO size is hardcoded
            handler.PopulateWithTestData(garage);
        }
        private void Menu()
        {
            ui.PrintLine("Garage 1.0");
            do
            {
                ui.PrintLine("1 - Create a garage");
                ui.PrintLine("0 - Quit");
                int choice = ui.ReadInt();
                // TODO switch
            }
            while (true);
        }

        // TODO Create garage menu
        // Add car menu
        // Add bus menu
        // Print stuff menus....
    }
}
