using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    class Airplane : Vehicle
    {
        public int Wingspan { get; set; }


        public Airplane(string regNumber, string color, int numberOfWheels, int wingSpan)
            : base(regNumber, VehicleType.Airplane, color, numberOfWheels)
        {
            Wingspan = wingSpan;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\tWingspan: {Wingspan}";
        }
    }
}
