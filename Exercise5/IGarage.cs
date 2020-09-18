using System;
using System.Collections;
using System.Collections.Generic;

namespace Exercise5
{
    public interface IGarage
    {
        IVehicle this[int index] { get; }
        int Capacity { get; }
        void Resize(int newSize);
        int GetFreeSpotIndex { get; }
        bool Add(IVehicle vehicle);
        IEnumerator GetEnumerator();
        List<Tuple<VehicleType, int>> GetNumberOfVehiclesPerType();
        IVehicle GetVehicle(string regNumber);
        List<IVehicle> GetVehicles(string color);
        List<IVehicle> GetVehicles(string color, int wheels);
        List<IVehicle> GetVehicles(VehicleType type);
        List<IVehicle> GetVehicles(VehicleType type, string color, int wheels);
        bool RemoveVehicle(string regNumber);
    }
}