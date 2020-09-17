using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Exercise5.Tests
{
    [TestClass]
    public class GarageTest
    {
        // Utility method. Changes to this will break tests. If changed, check/update tests
        // using this utility method.
        private static Garage<IVehicle> CreateAndPopulateGarage()
        {
            return new Garage<IVehicle>(10)
            {
                new Car("ABC123", "Blue", 4, FuelType.Gasoline),
                new Car("cde123", "Green", 4, FuelType.Gasoline),
                new Car("xYz123", "Blue", 4, FuelType.Gasoline),
                new Bus("CBA987", "Yellow", 4, 40),
            };
        }

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
            Assert.AreEqual("ABC123", fetchedCar.RegNumber);
        }

        [TestMethod]
        public void Garage_GetVehicleOnRegnumber_Found()
        {
            Garage<IVehicle> vehicleGarage = CreateAndPopulateGarage();
            IVehicle v = vehicleGarage.GetVehicle("Cde123");
            Assert.AreEqual("CDE123", v.RegNumber);  // Reg number stored uppercase
        }
        [TestMethod]
        public void Garage_GetVehicleOnRegnumber_NotFound()
        {
            Garage<IVehicle> vehicleGarage = CreateAndPopulateGarage();
            IVehicle v = vehicleGarage.GetVehicle("123456");
            Assert.IsNull(v);
        }

        [TestMethod]
        public void Garage_GetVehiclesOnColor_Found()
        {
            Garage<IVehicle> vehicleGarage = CreateAndPopulateGarage();
            List<IVehicle> v = vehicleGarage.GetVehicles("Blue");
            Assert.AreEqual(2, v.Count);
        }

        [TestMethod]
        public void Garage_GetVehiclesOnType_Found()
        {
            Garage<IVehicle> vehicleGarage = CreateAndPopulateGarage();
            List<IVehicle> v = vehicleGarage.GetVehicles(VehicleType.Car);
            Assert.AreEqual(3, v.Count);
        }

        [TestMethod]
        public void Garage_GetVehiclesOnTypeColorWheels_Found()
        {
            Garage<IVehicle> vehicleGarage = CreateAndPopulateGarage();
            List<IVehicle> v = vehicleGarage.GetVehicles(VehicleType.Car, "Blue", 4);
            Assert.AreEqual(2, v.Count);
        }

        [TestMethod]
        public void Garage_GetVehiclesOnColorWheels_Found()
        {
            Garage<IVehicle> vehicleGarage = CreateAndPopulateGarage();
            List<IVehicle> v = vehicleGarage.GetVehicles("Blue", 4);
            Assert.AreEqual(2, v.Count);
        }

        [TestMethod]
        public void Garage_RemoveVehicleOnRegnumber_Successful()
        {
            Garage<Vehicle> vehicleGarage = new Garage<Vehicle>(10)
            {
                new Car("ABC123", "Blue", 4, FuelType.Gasoline),
                new Car("cde123", "Blue", 4, FuelType.Gasoline),
                new Car("xYz123", "Blue", 4, FuelType.Gasoline)
            };
            //Verify that spot is occupied
            Assert.IsNotNull(vehicleGarage[0]);
            Assert.IsTrue(vehicleGarage.RemoveVehicle("ABC123"));
            // Verify that spot is empty
            Assert.IsNull(vehicleGarage[0]);
        }
        [TestMethod]
        public void Garage_RemoveVehicleOnRegnumber_Notfound()
        {
            Garage<Vehicle> vehicleGarage = new Garage<Vehicle>(10)
            {
                new Car("ABC123", "Blue", 4, FuelType.Gasoline),
                new Car("cde123", "Blue", 4, FuelType.Gasoline)
            };
            //Verify that spots are occupied
            Assert.IsNotNull(vehicleGarage[0]);
            Assert.IsNotNull(vehicleGarage[1]);
            Assert.IsFalse(vehicleGarage.RemoveVehicle("ZZZZZZ"));
            // Verify that spots still are occupied
            Assert.IsNotNull(vehicleGarage[0]);
            Assert.IsNotNull(vehicleGarage[1]);
        }

        [TestMethod]
        public void Garage_GetFreeSpot_Success()
        {
            Garage<Vehicle> vehicleGarage = new Garage<Vehicle>(10)
            {
                new Car("ABC123", "Blue", 4, FuelType.Gasoline),
                new Car("cde123", "Blue", 4, FuelType.Gasoline)
            };
            int expectedIndex = 2;
            int freeSpot = vehicleGarage.GetFreeSpotIndex;
            Assert.AreEqual(expectedIndex, freeSpot);
        }

        [TestMethod]
        public void Garage_GetNumberOfVehicles_Success()
        {
            Garage<IVehicle> vehicleGarage = CreateAndPopulateGarage();
            int expectedListCount = 2;
            int expectedNoCars = 3;
            VehicleType expectedType = VehicleType.Car;
            var result = vehicleGarage.GetNumberOfVehicles();
            Assert.AreEqual(expectedListCount, result.Count);
            (VehicleType type, int count) = result.First();
            Assert.AreEqual(expectedType, type);
            Assert.AreEqual(expectedNoCars, count);
        }

        [TestMethod]
        public void Garage_FindFreeSpot_Success()
        {
            Garage<IVehicle> vehicleGarage = CreateAndPopulateGarage();
            int expectedFreeSpot = 4;
            int freeSpotFound = vehicleGarage.GetFreeSpotIndex;
            Assert.AreEqual(expectedFreeSpot, freeSpotFound);
        }

        [TestMethod]
        public void Garage_FindFreeSpot_NotFound()
        {
            Garage<IVehicle> vehicleGarage = new Garage<IVehicle>(1);
            vehicleGarage.Add(new Car("ABC123", "Blue", 4, FuelType.Gasoline));
            int expectedFreeSpot = -1;
            int freeSpotFound = vehicleGarage.GetFreeSpotIndex;
            Assert.AreEqual(expectedFreeSpot, freeSpotFound);
        }
    }

}
