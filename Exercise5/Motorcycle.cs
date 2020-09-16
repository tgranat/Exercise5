using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; set; }


        public Motorcycle(string regNumber, string color, int numberOfWheels, int cylinderVolume)
            : base(regNumber, VehicleType.Motorcycle, color, numberOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\tCylinder volume: {CylinderVolume}";
        }
    }
}
