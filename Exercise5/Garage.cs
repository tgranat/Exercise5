using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    public class Garage<T> : IEnumerable where T : Vehicle
    {
        private Vehicle[] garage;
        private int nextFreeSpot;

        public Garage(int sizeOfGarage)
        {
            garage = new Vehicle[sizeOfGarage];
            nextFreeSpot = 0;
        }


        public IEnumerator GetEnumerator()
        {
            foreach (var item in garage)
            {
                yield return item;
            }
        }

        public bool ParkingSpotAvailable() => nextFreeSpot < garage.Length;
    }
}
