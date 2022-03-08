using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bus;

namespace Bus
{
    [TestClass]
    internal class Tests
    {
        [TestMethod]
        public void TestingBuses()
        {
            Bus bus = Data.AllBuses.Find(x => x.Number == 91);
            Station station = Data.AllStations.Find(y => y.Name == "Высокая Гора");
            Assert.IsTrue(bus.CanMoveToStation(station));
            Assert.IsTrue(station.IsBusVisitsStation(bus));
        }
    }
}
