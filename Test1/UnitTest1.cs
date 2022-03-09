using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bus;
using System.Linq;

namespace Test1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Bus.Bus bus = Data.AllBuses.Find(x => x.Number == 91);
            Station station = Data.AllStations.Find(y => y.Name == "Высокая Гора");
            Assert.IsTrue(bus.CanMoveToStation(station));
            Assert.IsTrue(station.IsBusVisitsStation(bus));
        }
    }
}
