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

        public bool IsGarageFull(IGarage garage) => garage.GetFreeSpotIndex < 0;

        public bool IsVehicleParked(IGarage garage, string regNumber) => garage.GetVehicle(regNumber) != null;

        public string GetVehicle(IGarage garage, string regNumber) => garage.GetVehicle(regNumber)?.ToString();

        public bool CreateCar(IGarage garage, string regNumber, string color, int wheels, FuelType fuel) =>
             garage.Add(new Car(regNumber, color, wheels, fuel));

        public bool CreateBus(IGarage garage, string regNumber, string color, int wheels, int seats) =>
             garage.Add(new Bus(regNumber, color, wheels, seats));

        public bool CreateMotorcycle(IGarage garage, string regNumber, string color, int wheels, int volume) =>
            garage.Add(new Motorcycle(regNumber, color, wheels, volume));
        public bool CreateBoat(IGarage garage, string regNumber, string color, int wheels, int length) =>
             garage.Add(new Boat(regNumber, color, wheels, length));

        public bool CreateAirplane(IGarage garage, string regNumber, string color, int wheels, int wingSpan) =>
           garage.Add(new Airplane(regNumber, color, wheels, wingSpan));

        public bool RemoveVehicle(IGarage garage, string regNumber) =>
            garage.RemoveVehicle(regNumber);

        // Return List<string> of all parking spaces including not occupied
        public List<string> GetParkingSpaceData(IGarage garage)
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
        public List<string> GetParkedVehicles(IGarage garage)
        {
            List<string> vehicleData = new List<string>();
            foreach (var item in garage)
            {
                if (item != null) vehicleData.Add(item.ToString());
            }
            return vehicleData;
        }

        // Return vehicles of a specific color as strings
        public List<string> GetVehicles(IGarage garage, string color)
        {
            List<string> vehicles = new List<string>();
            garage.GetVehicles(color).ForEach(v => vehicles.Add(v.ToString()));
            return vehicles;
        }

        public List<string> GetVehicles(IGarage garage, string color, int wheels)
        {
            List<string> vehicles = new List<string>();
            garage.GetVehicles(color, wheels).ForEach(v => vehicles.Add(v.ToString()));
            return vehicles;
        }

        public List<string> GetVehicles(IGarage garage, VehicleType type)
        {
            List<string> vehicles = new List<string>();
            garage.GetVehicles(type).ForEach(v => vehicles.Add(v.ToString()));
            return vehicles;
        }

        public List<string> GetVehicles(IGarage garage, VehicleType type, string color, int wheels)
        {
            List<string> vehicles = new List<string>();
            garage.GetVehicles(type, color, wheels).ForEach(v => vehicles.Add(v.ToString()));
            return vehicles;
        }

        public List<string> GetNumberOfVehicles(IGarage garage)
        {
            List<string> vehicles = new List<string>();
            garage.GetNumberOfVehicles().ForEach(t => vehicles.Add($"{t.Item1}:\t{t.Item2}"));
            return vehicles;
        }
    }
}
