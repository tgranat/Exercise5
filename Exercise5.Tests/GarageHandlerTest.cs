using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5.Tests
{
    class GarageHandlerTest
    {
        [TestMethod]
        public void GarageHandler_Garage_Success()
        {
            GarageHandler h = new GarageHandler();
            Garage<IVehicle> g = h.CreateGarage(10);
            Assert.IsNotNull(g);
        }
    }
}

