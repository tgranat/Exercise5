using System.Collections.Generic;

namespace Exercise5
{
     public class GarageHandler
    {
        public IGarage CreateGarage(int size)
        {
            return new Garage<IVehicle>(size);
        }

        public void PopulateWithTestData(IGarage garage)
        {
            garage.Add(new Car("ABC123", "Blue", 4, FuelType.Gasoline));
            garage.Add(new Car("CDE123", "Green", 3, FuelType.Gasoline));
            garage.Add(new Car("FGH123", "Blue", 4, FuelType.Gasoline));
            garage.Add(new Bus("AB6767767", "Blue", 6, 40));
            garage.Add(new Airplane("78784543", "White", 3, 20));
            garage.Add(new Motorcycle("iuy432", "red", 2, 750));
            garage.Add(new Motorcycle("J88888", "black", 3, 500));
            garage.Add(new Boat("77876GGG", "brown", 0, 9));

        }
    }
}
