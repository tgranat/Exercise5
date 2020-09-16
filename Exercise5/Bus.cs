using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    public class Bus : Vehicle
    {
        public int Seats { get; set; }


        public Bus(string regNumber, string color, int numberOfWheels, int seats)
            : base(regNumber, VehicleType.Bus, color, numberOfWheels)
        {
            Seats = seats;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\tSeats: {Seats}";
        }
    }
}
