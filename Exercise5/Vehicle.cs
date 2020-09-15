using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    // TODO extract interface
    public abstract class Vehicle
    {
        private string regNumber;

        // Alpabetic characters in RegNumber is always stored in uppercase
        public string RegNumber
        {
            get { return regNumber; }
            set { regNumber = value.ToUpper(); }
        }

        public VehicleType VehicleType { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }

        public Vehicle(string regNumber, VehicleType type, string color, int numberOfWheels)
        {
            RegNumber = regNumber;    // regnumber should be unique but is tested when added to Garage
            VehicleType = type;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        public override string ToString()
        {
            return $"Reg number: {RegNumber} Color: {Color} Wheels: {NumberOfWheels}";
        }
        
        
      
    }
}
