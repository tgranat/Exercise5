using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private Vehicle[] garage;

        public Garage(int sizeOfGarage)
        {
            garage = new Vehicle[sizeOfGarage];
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
