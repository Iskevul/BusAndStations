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

            Bus bus = Data.AllBuses.Find(x => x.Number == 91);
            Station station = Data.AllStations.Find(y => y.Name == "������� ����");

            Assert.IsTrue(bus.CanMoveToStation(station));
            Assert.IsTrue(station.IsBusVisitsStation(bus));
        }
    }
}
