using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
     public class GarageHandler : IGarageHandler
    {
        public Garage<IVehicle> CreateGarage(int size)
        {
            return new Garage<IVehicle>(size);
        }

        public void PopulateWithTestData(Garage<IVehicle> garage)
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

        public bool IsGarageFull(Garage<IVehicle> garage) => garage.GetFreeSpotIndex < 0;

        public bool IsVehicleParked(Garage<IVehicle> garage, string regNumber) => garage.GetVehicle(regNumber) != null;

        public string GetVehicle(Garage<IVehicle> garage, string regNumber) => garage.GetVehicle(regNumber)?.ToString();

        public bool CreateCar(Garage<IVehicle> garage, string regNumber, string color, int wheels, FuelType fuel) =>
             garage.Add(new Car(regNumber, color, wheels, fuel));

        public bool CreateBus(Garage<IVehicle> garage, string regNumber, string color, int wheels, int seats) =>
             garage.Add(new Bus(regNumber, color, wheels, seats));

        public bool CreateMotorcycle(Garage<IVehicle> garage, string regNumber, string color, int wheels, int volume) =>
            garage.Add(new Motorcycle(regNumber, color, wheels, volume));
        public bool CreateBoat(Garage<IVehicle> garage, string regNumber, string color, int wheels, int length) =>
             garage.Add(new Boat(regNumber, color, wheels, length));

        public bool CreateAirplane(Garage<IVehicle> garage, string regNumber, string color, int wheels, int wingSpan) =>
           garage.Add(new Airplane(regNumber, color, wheels, wingSpan));

        public bool RemoveVehicle(Garage<IVehicle> garage, string regNumber) =>
            garage.RemoveVehicle(regNumber);

        // Return List<string> of all parking spaces including not occupied
        public List<string> GetParkingSpaceData(Garage<IVehicle> garage)
        {
            List<string> garageData = new List<string>();
            for (int i = 0; i < garage.Capacity; i++)
            {
                if (garage[i] == null)
                    garageData.Add($"{i}.\tFree space");
                else
                    garageData.Add($"{i}.\t{garage[i]}");
            }
            return garageData;
        }

        // Return parked vehicles as strings
        public List<string> GetParkedVehicles(Garage<IVehicle> garage)
        {
            List<string> vehicleData = new List<string>();
            foreach (var item in garage)
            {
                if (item != null) vehicleData.Add(item.ToString());
            }
            return vehicleData;
        }

        // Return vehicles of a specific color as strings
        public List<string> GetVehicles(Garage<IVehicle> garage, string color)
        {
            List<string> vehicles = new List<string>();
            garage.GetVehicles(color).ForEach(v => vehicles.Add(v.ToString()));
            return vehicles;
        }

        public List<string> GetVehicles(Garage<IVehicle> garage, string color, int wheels)
        {
            List<string> vehicles = new List<string>();
            garage.GetVehicles(color, wheels).ForEach(v => vehicles.Add(v.ToString()));
            return vehicles;
        }

        public List<string> GetVehicles(Garage<IVehicle> garage, VehicleType type)
        {
            List<string> vehicles = new List<string>();
            garage.GetVehicles(type).ForEach(v => vehicles.Add(v.ToString()));
            return vehicles;
        }

        public List<string> GetVehicles(Garage<IVehicle> garage, VehicleType type, string color, int wheels)
        {
            List<string> vehicles = new List<string>();
            garage.GetVehicles(type, color, wheels).ForEach(v => vehicles.Add(v.ToString()));
            return vehicles;
        }

        public List<string> GetNumberOfVehicles(Garage<IVehicle> garage)
        {
            List<string> vehicles = new List<string>();
            garage.GetNumberOfVehicles().ForEach(t => vehicles.Add($"{t.Item1}:\t{t.Item2}"));
            return vehicles;
        }
    }
}
