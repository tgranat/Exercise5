using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5.Tests
{
    class GarageHandlerTest
    {
        [TestMethod]
        public void GarageHandler_CreateCar_Success()
        {
            GarageHandler h = new GarageHandler();
            Garage<IVehicle> g = h.CreateGarage(10);
            bool result = h.CreateCar(g, "ABC123", "Green", 4, FuelType.Diesel);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GarageHandler_CreateBus_Success()
        {
            GarageHandler h = new GarageHandler();
            Garage<IVehicle> g = h.CreateGarage(10);
            Assert.IsTrue(h.CreateBus(g, "ABC123", "Green", 4, 40));
        }
        [TestMethod]
        public void GarageHandler_RemoveVehicle_Success()
        {
            GarageHandler h = new GarageHandler();
            Garage<IVehicle> g = h.CreateGarage(10);
            h.CreateBus(g, "ABC123", "Green", 4, 40);
            h.CreateCar(g, "CDE123", "Green", 4, FuelType.Diesel);
            Assert.IsTrue(h.RemoveVehicle(g, "ABC123"));          
        }
    }
}

