using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Bus
{
    [TestClass]
    public class UnitTest1
    {
        public static Station st1 = new Station("ЦУМ");
        public static Station st2 = new Station("Советская");
        public static Station st3 = new Station("Абжалилова");
        public static Bus bus91 = new Bus("91", new Station[] { st1, st2 });
        public static Bus bus63 = new Bus("63", new Station[] { st2, st3 });

        [TestMethod]
        public void DataAmountTest()
        {
            int expectedBusesAmount = 2;
            int expectedStationsAmount = 3;
            Assert.AreEqual(expectedBusesAmount, Data.AllBuses.Count, "amounts are not equal");
            Assert.AreEqual(expectedStationsAmount, Data.AllStations.Count, "amounts are not equal");
        }
        [TestMethod]
        public void BusesForStationTest()
        {
            Station st1 = new Station("ЦУМ");
            Station st2 = new Station("Советская");
            Station st3 = new Station("Абжалилова");
            Bus bus91 = new Bus("91", new Station[] { st1, st2 });
            Bus bus63 = new Bus("63", new Station[] { st2, st3 });
            string expectedBuses = "91";
            Assert.AreEqual(expectedBuses, Data.FindBusesForStation("ЦУМ"));
        }
    }
}
