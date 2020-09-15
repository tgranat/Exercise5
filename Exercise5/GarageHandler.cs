using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    // För abstraktion
    // TODO extract handler interface

    public class GarageHandler
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
            garage.Add(new Bus("sdfsdf", "Lilac", 6, 40));            
        }

        public bool CreateCar(Garage<IVehicle> garage, string regNumber, string color, int wheels, FuelType fuel) =>
             garage.Add(new Car(regNumber, color, wheels, fuel));

        public bool CreateBus(Garage<IVehicle> garage, string regNumber, string color, int wheels, int seats) =>
             garage.Add(new Bus(regNumber, color, wheels, seats));

        public bool RemoveVehicle(Garage<IVehicle> garage, string regNumber) =>
            garage.RemoveVehicle(regNumber);

        // Return List<string> of all parking spaces including not occupied
        public List<string> GetParkingSpaceData(Garage<IVehicle> garage)
        {
            List<string> garageData = new List<string>();
            for (int i = 0; i < garage.Capacity; i++)
            {
                if (garage[i] == null)
                    garageData.Add($"{i};\tFree space");
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
    }
}
