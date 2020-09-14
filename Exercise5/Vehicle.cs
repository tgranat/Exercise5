using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    public abstract class Vehicle
    {
        public string RegNumber { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }

        public Vehicle(string regNumber, string color, int numberOfWheels)
        {
            RegNumber = regNumber;    // regnumber is unique, check that. Do it in Garage?
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        public override string ToString()
        {
            return $"Reg number: {RegNumber} Color: {Color} Wheels: {NumberOfWheels}";
        }
    }
}
