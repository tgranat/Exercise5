using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise5.Tests
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void Car_CreateObject_Success()
        {
            Car car = new Car("ABC123", "Green", 4, FuelType.Diesel);
        }
    }
}
