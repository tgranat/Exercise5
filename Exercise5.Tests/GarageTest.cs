using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5.Tests
{
    [TestClass]
    public class GarageTest
    {
        [TestMethod]
        public void Garage_CreateVehicleGarageSize10_Success()
        {
            Garage<Vehicle> vehicleGarage = new Garage<Vehicle>(10);

        }

        [TestMethod]
        public void Garage_CreateCarGarageSize10_Success()
        {
            Garage<Car> carGarage = new Garage<Car>(10);

        }

        // build error
        //[TestMethod]
        //public void Garage_CreateStringGarage_Fail()
        //{
        //    Garage<string> carGarage = new Garage<string>(10);

        //}
    }

}
