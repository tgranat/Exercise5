﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exercise5
{
    // Stores a generic collection of type Vehicle or its subclasses.

    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private T[] garage; 
 
        // Create a Garage with a specified number of parking spaces.
        // Empty parking spaces are null
        public Garage(int sizeOfGarage)
        {
            garage = new T[sizeOfGarage];
        }
       
        // Resize (ths creates a new array and copies the elements)
        public void Resize(int newSize)
        {
            Array.Resize<T>(ref garage, newSize);
        }

        // Declare indexer
        public T this[int index] => garage[index];


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in garage)
            {
                if (item != null) yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // Return total number of elements in the garage array
        public int Capacity => garage.Length;

        // Get next free parking spot. Return -1 if no free spots.
        public int GetFreeSpotIndex => Array.FindIndex(garage, v => v == null);

        // Add IVehicle to garage. Return false if no parking space available or 
        // vehicle with the same registration number already parked.
        public bool Add(IVehicle vehicle)
        {
            int spot = GetFreeSpotIndex;
            if (spot < 0) return false;
            if (GetVehicle(vehicle.RegNumber) != null) return false;
            garage[spot] = (T)vehicle;
            return true;
        }

        // Get a Vehicle based on reg number. Returns null if not found
        public IVehicle GetVehicle(string regNumber)
        {
            var vehicle = garage
                .Where(v => v?.RegNumber == regNumber.ToUpper())
                .FirstOrDefault();
            return vehicle;
        }

        // Remove a vehicle based on reg number.
        // Lookup index and set element to null
        // Return false if nothing removed
        public bool RemoveVehicle(string regNumber)
        {
            int index = Array.FindIndex<T>(garage, v => v?.RegNumber == regNumber.ToUpper());
            if (index < 0) return false;
            garage[index] = default;
            return true;
        }

        // Return a List of tuples containing VehicleType and number of vehicles per type
        public List<Tuple<VehicleType, int>> GetNumberOfVehiclesPerType()
        {
            List<Tuple<VehicleType, int>> result = new List<Tuple<VehicleType, int>>();
            var group = garage.GroupBy(v => v?.Type);  // returns a IEnumerable of IGrouping
            foreach (var item in group)
            {
                if (item != null && item.Key != null)
                {
                    result.Add(Tuple.Create((VehicleType)item.Key, item.Count()));
                }
            }
            return result;
        }

        // List Vehicle with certain type, color and number of wheels
        public List<T> GetVehicles(VehicleType type, string color, int wheels)
        {
            var result = garage
                .Where(v => v?.Type == type)
                .Where(v => v?.Color == color.ToUpper())
                .Where(v => v?.NumberOfWheels == wheels)
                .ToList();
            return result;
        }

        // List Vehicle with certain color and number of wheels
        public List<T> GetVehicles(string color, int wheels)
        {
            var result = garage
                .Where(v => v?.Color == color.ToUpper())
                .Where(v => v?.NumberOfWheels == wheels)
                .ToList();
            return result;
        }

  
        // List vehicles of certain color
        public List<T> GetVehicles(string color)
        {
            var result = garage
                .Where(v => v?.Color == color.ToUpper())
                .ToList();
            return result;
        }
        // List vehicles of certain type
        public List<T> GetVehicles(VehicleType type)
        {
            var result = garage
                .Where(v => v?.Type == type)
                .ToList();
            return result;
        }
    }
}
