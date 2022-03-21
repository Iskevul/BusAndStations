using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bus
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Data.FillData();
            Data.FillStArr();
            Data.FillStDict();

            Bus bus = Data.AllBuses.Find(x => x.GetNumber() == "91");
            Station station = Data.AllStations.Find(y => y.GetName() == "Высокая Гора");

            Assert.IsTrue(bus.CanMoveToStation(station));
            Assert.IsTrue(station.IsBusVisitsStation(bus));
        }
    }
}
