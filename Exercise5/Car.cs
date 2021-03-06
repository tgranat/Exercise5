﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    public class Car : Vehicle
    {
        public FuelType FuelType { get; set; }


        public Car(string regNumber, string color, int numberOfWheels, FuelType fuelType)
            : base(regNumber, VehicleType.Car, color, numberOfWheels)
        {
            FuelType = fuelType;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\tFuel type: {FuelType}";
        }
    }
}
