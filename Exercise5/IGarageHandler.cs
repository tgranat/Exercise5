using System.Collections.Generic;

namespace Exercise5
{
    public interface IGarageHandler
    {
        bool CreateAirplane(Garage<IVehicle> garage, string regNumber, string color, int wheels, int wingSpan);
        bool CreateBoat(Garage<IVehicle> garage, string regNumber, string color, int wheels, int length);
        bool CreateBus(Garage<IVehicle> garage, string regNumber, string color, int wheels, int seats);
        bool CreateCar(Garage<IVehicle> garage, string regNumber, string color, int wheels, FuelType fuel);
        Garage<IVehicle> CreateGarage(int size);
        bool CreateMotorcycle(Garage<IVehicle> garage, string regNumber, string color, int wheels, int volume);
        List<string> GetNumberOfVehicles(Garage<IVehicle> garage);
        List<string> GetParkedVehicles(Garage<IVehicle> garage);
        List<string> GetParkingSpaceData(Garage<IVehicle> garage);
        string GetVehicle(Garage<IVehicle> garage, string regNumber);
        List<string> GetVehicles(Garage<IVehicle> garage, string color);
        List<string> GetVehicles(Garage<IVehicle> garage, string color, int wheels);
        List<string> GetVehicles(Garage<IVehicle> garage, VehicleType type);
        List<string> GetVehicles(Garage<IVehicle> garage, VehicleType type, string color, int wheels);
        bool IsGarageFull(Garage<IVehicle> garage);
        bool IsVehicleParked(Garage<IVehicle> garage, string regNumber);
        void PopulateWithTestData(Garage<IVehicle> garage);
        bool RemoveVehicle(Garage<IVehicle> garage, string regNumber);
    }
}