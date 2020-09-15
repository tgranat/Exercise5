using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Exercise5
{
    // TODO extract interface
    public abstract class Vehicle
    {
        private string regNumber;
        private string color;

        // Alpabetic characters in RegNumber is always stored in uppercase
        public string RegNumber
        {
            get { return regNumber; }
            set { regNumber = value.ToUpper(); }
        }

        // Alpabetic characters in Color is always stored in uppercase.
        // Need to spell it correctly
        public string Color
        {
            get { return color; }
            set { color = value.ToUpper(); }
        }   
        public VehicleType VehicleType { get; set; }
       
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
