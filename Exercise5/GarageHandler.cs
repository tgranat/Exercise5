using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    // För abstraktion
    // TODO extract interface
    public class GarageHandler
    {
        //private Garage<IVehicle> garage;

        public Garage<IVehicle> CreateGarage(int size)
        {
            return new Garage<IVehicle>(size);
        }

        public void PopulateWithTestData(Garage<IVehicle> garage)
        {
            garage.Add(new Car("ABC123", "Blue", 4, FuelType.Gasoline));
            garage.Add(new Car("CDE123", "Green", 3, FuelType.Gasoline));
            garage.Add(new Car("FGH123", "Blue", 4, FuelType.Gasoline));
            garage.Add(new Bus("sdfsdf", "Lilac", 6, 40));            
        }

        // create Garage (factory)
        // Garage garage = GarageHandler.CreateGarage(size);
        // GarageHandler.PopulateWithTestData(garage);

        // implement functionality for UI:
        // 

        // Handler.CreateCar(garage, dfdf,dfdff,dfd.....);  ??

        // List<IVehicle> GarageHandler.GetAllVehicles()....
    }
}
