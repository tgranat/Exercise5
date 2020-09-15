using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise5.Tests
{
    [TestClass]
    public class VehicleTest
    {
        [TestMethod]
        public void Car_CreateObject_Success()
        {
            Car car = new Car("ABC123", "Green", 4, FuelType.Diesel);
            Assert.AreEqual(FuelType.Diesel, car.FuelType);
        }

        [TestMethod]
        public void Bus_CreateObject_Success()
        {
            Bus bus = new Bus("ABC123", "Green", 4, 40);
            Assert.AreEqual(40, bus.Seats);
        }
    }
}
