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

        public void Run()
        {
            // create IUI
            Initialize();
            Menu();
        }

        private void Initialize()
        {
            handler = new GarageHandler();
            garage = handler.CreateGarage(10);  // TODO size is hardcoded
            handler.PopulateWithTestData(garage);
        }
        private void Menu()
        {

        }
    }
}
