using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    class Boat : Vehicle
    {
        public int Length { get; set; }


        public Boat(string regNumber, string color, int numberOfWheels, int length)
            : base(regNumber, VehicleType.Boat, color, numberOfWheels)
        {
            Length = length;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\tLength: {Length}";
        }
    }
}
