using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise5
{
    // Stores a generic collection of type Vehicle or its subclasses.

    public class Garage<T> : IEnumerable where T : Vehicle
    {
        private Vehicle[] garage;
 
        // Create a Garage with a specified number of parking spaces.
        // Empty parking spaces are null
        public Garage(int sizeOfGarage)
        {
            garage = new Vehicle[sizeOfGarage];
        }

        // Declare index
        public Vehicle this[int index] => garage[index];

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

        public bool Add(Vehicle vehicle)
        {
            // TODO: check regnumber here? 
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
        public Vehicle GetVehicle(string regNumber)
        {
            var vehicle = garage
                .Where(v => v?.RegNumber == regNumber.ToUpper())
                .FirstOrDefault();
            return vehicle;
        }



        // TODO locate vehicle from en egenskap eller flera och på fordonstyp

        // TODO remove vehicle on regnumber
        // TODO find vehicle on regnumber

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
