using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    // Stores a generic collection of type Vehicle or its subclasses.

    public class Garage<T> : IEnumerable where T : Vehicle
    {
        private Vehicle[] garage;
        //private int nextFreeSpot;  // TODO fix this, there might be free spaces in the middle of the array

        // Creating a Garage with a specified number of parking spaces.
        // Empty parking spaces are null
        public Garage(int sizeOfGarage)
        {
            garage = new Vehicle[sizeOfGarage];
            //nextFreeSpot = 0;
        }

        public Vehicle this[int index] => garage[index];

        public IEnumerator GetEnumerator()
        {
            foreach (var item in garage)
            {
                yield return item;
            }
        }

        public int Capacity => garage.Length;

        public bool IsParkingSpotAvailable() => NextAvailableSpot() < Capacity;

        // Scan garage for null spot = available parking lot
        // If none available it returns garage.Lenght
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

        public bool Add(Vehicle vehicle)
        {
            // TODO: check regnumber here? Own method?
            if (IsParkingSpotAvailable())
            {
                garage[NextAvailableSpot()] = vehicle;
                return true;
            }
            else
            {
                return false;
            }
        }

        // TODO remove vehicle on regnumber
    }
}
