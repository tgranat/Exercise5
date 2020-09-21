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

        
    }
}
