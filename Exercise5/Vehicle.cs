﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Exercise5
{
    // TODO extract interface

    public abstract class Vehicle : IVehicle
    {

        public string RegNumber { get; }

        public string Color { get; }

        public VehicleType Type { get; }
        public int NumberOfWheels { get; }

        public Vehicle(string regNumber, VehicleType type, string color, int numberOfWheels)
        {
            // Alpabetic characters in RegNumber is always stored in uppercase
            RegNumber = regNumber.ToUpper();    // TODO regnumber should be unique but should  tested when added to Garage
            Type = type;
            // Alpabetic characters in Color is always stored in uppercase.
            // Need to spell it correctly
            Color = color.ToUpper();
            NumberOfWheels = numberOfWheels;
        }

        public override string ToString()
        {
            return $"Reg number: {RegNumber} Type: {Type} Color: {Color} Wheels: {NumberOfWheels}";
        }



    }
}
