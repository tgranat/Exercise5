using System.Collections.Generic;

namespace Exercise5
{
     public class GarageHandler
    {
        public IGarage CreateGarage(int size) => new Garage<IVehicle>(size);
   
        public IVehicle CreateCar(string regNumber, string color, int wheels, FuelType fuel) =>
            new Car(regNumber, color, wheels, fuel);

        public IVehicle CreateBus(string regNumber, string color, int wheels, int seats) =>
            new Bus(regNumber, color, wheels, seats);

        public IVehicle CreateMotorCycle(string regNumber, string color, int wheels, int volume) =>
            new Motorcycle(regNumber, color, wheels, volume);

        public IVehicle CreateBoat(string regNumber, string color, int wheels, int length) =>
            new Boat(regNumber, color, wheels, length);

        public IVehicle CreateAirplane(string regNumber, string color, int wheels, int wingSpan) =>
            new Airplane(regNumber, color, wheels, wingSpan);

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
