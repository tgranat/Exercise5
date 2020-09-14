using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
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


        [TestMethod]
        public void Garage_Foreach_Success()
        {
            int expected = 10;
            Garage<Vehicle> vehicleGarage = new Garage<Vehicle>(expected);
            int actual = 0;
            foreach (var item in vehicleGarage)
            {
                actual++;
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Garage_AvailableSpot_Success()
        {
            Garage<Vehicle> vehicleGarage = new Garage<Vehicle>(10);
            bool available = vehicleGarage.IsParkingSpotAvailable();
            Assert.IsTrue(available);
        }

        [TestMethod]
        public void Garage_AvailableSpot_NotAvailable()
        {
            Garage<Vehicle> vehicleGarage = new Garage<Vehicle>(0);
            bool available = vehicleGarage.IsParkingSpotAvailable();
            Assert.IsFalse(available);
        }
        [TestMethod]
        public void Garage_AddCarToVehicleGarage_Success()
        {
            Garage<Vehicle> vehicleGarage = new Garage<Vehicle>(10);
            Car car = new Car("ABC123", "Blue", 4, FuelType.Gasoline);
            Assert.IsTrue(vehicleGarage.Add(car));
        }

        [TestMethod]
        public void Garage_AddCarToCarGarage_Success()
        {
            Garage<Car> carGarage = new Garage<Car>(10);
            Car car = new Car("ABC123", "Blue", 4, FuelType.Gasoline);
            Assert.IsTrue(carGarage.Add(car));
        }


        [TestMethod]
        public void Garage_AddCarToVehicleGarage_FailsGarageFull()
        {
            Garage<Vehicle> vehicleGarage = new Garage<Vehicle>(1);
            Car car1 = new Car("ABC123", "Blue", 4, FuelType.Gasoline);
            Car car2 = new Car("ABC456", "Green", 4, FuelType.Gasoline);
            vehicleGarage.Add(car1);
            Assert.IsFalse(vehicleGarage.Add(car2));

        }

        [TestMethod]
        public void Garage_GetCarFromVehicleGarageWithIndex_Success()
        {
            Garage<Vehicle> vehicleGarage = new Garage<Vehicle>(10)
            {
                new Car("ABC123", "Blue", 4, FuelType.Gasoline)
            };

            Car fetchedCar = vehicleGarage[0] as Car;
            Assert.AreEqual(fetchedCar.RegNumber, "ABC123");
        }

         //[TestMethod]
        //public void Garage_FetchWithIndex_Success()
        //{

        //}

        //[TestMethod]
        //public void Garage_FetchWithIndex_Outofbounds()
        //{

        //}

    }

}
