﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise5
{
    // Stores a generic collection of type Vehicle or its subclasses.

    public class Garage<T> : IEnumerable where T : IVehicle
    {
        private IVehicle[] garage;
 
        // Create a Garage with a specified number of parking spaces.
        // Empty parking spaces are null
        public Garage(int sizeOfGarage)
        {
            garage = new IVehicle[sizeOfGarage];
        }

        // Declare index
        public IVehicle this[int index] => garage[index];

        public IEnumerator GetEnumerator()
        {
            foreach (var item in garage)
            {
                yield return item;
            }
        }

        public int Capacity => garage.Length;

        // Test if there is an available parking place somewhere in the array
        public bool IsParkingSpotAvailable => NextAvailableSpot() < Capacity;

        public bool Add(IVehicle vehicle)
        {
            // TODO: check regnumber here? Yes, dont store if already exist
            if (IsParkingSpotAvailable)
            {
                garage[NextAvailableSpot()] = vehicle;
                return true;
            }
            else
            {
                return false;
            }
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
            int index = Array.FindIndex(garage, v => v?.RegNumber == regNumber.ToUpper());
            if (index < 0) return false;
            garage[index] = null;
            return true;
        }

        // TODO lista fordonstyp och hur många av varje

        // List Vehicle with certain color and number of wheels
        public List<IVehicle> GetVehicles(string color, int wheels)
        {
            var result = garage
                .Where(v => v?.Color == color.ToUpper())
                .Where(v => v?.NumberOfWheels == wheels)
                .ToList();
            return result;
        }
        // List vehicles of certain color
        public List<IVehicle> GetVehicles(string color)
        {
            var result = garage
                .Where(v => v?.Color == color.ToUpper())
                .ToList();
            return result;
        }
        // List vehicles of certain type
        public List<IVehicle> GetVehicles(VehicleType type)
        {
            var result = garage
                .Where(v => v?.Type == type)
                .ToList();
            return result;
        }

         // Scan garage for null = available parking lot
        // If none available it returns capacity of garage
        private int NextAvailableSpot()
        {
            for (int i = 0; i < garage.Length; i++)
            {
                if (garage[i] == null)
                    return i;
            }
            // No parking space available
            return Capacity;
        }
    }
}
